using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NET.Data;
using NET.Data.Providers.Models;
using NET.Dto;
using NET.GenericRepository;
using NET.Helpers;

namespace NET.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ValidationService _validationService;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<AccountService> _logger;

        public AccountService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager,
                            IMapper mapper,
                            ValidationService validationService,
                            RoleManager<IdentityRole> roleManager,
                            IConfiguration configuration,
                            IHttpContextAccessor httpContextAccessor,
                            ILogger<AccountService> logger)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _validationService = validationService;
            _mapper = mapper;
            _roleManager = roleManager;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task<DBActionResult<ApplicationUser>> CreateUserAsync(RegisterDto registerDto)
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    var validationResult = await _validationService.ValidateRegisterDtoAsync(registerDto);
                    if (!validationResult.Succeeded)
                    {
                        return new DBActionResult<ApplicationUser>
                        {
                            IsSuccess = false,
                            ErrorMessage = validationResult.Errors.FirstOrDefault()?.Description ?? "An error occurred while saving the entity changes. See the inner exception for details.",
                            StatusCode = "400"
                        };
                    }
                    var newUser = _mapper.Map<ApplicationUser>(registerDto);

                    var result = await _userManager.CreateAsync(newUser, registerDto.Password);
                    if (result.Succeeded)
                    {
                        if (!await _roleManager.RoleExistsAsync(AppRole.User))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(AppRole.User));
                        }
                        await _userManager.AddToRoleAsync(newUser, AppRole.User);

                        await _unitOfWork.SaveChangesAsync();
                        await transaction.CommitAsync();
                        return DBActionResult<ApplicationUser>.Success(newUser);
                    }
                    return DBActionResult<ApplicationUser>.Failure(result.Errors.FirstOrDefault()?.Description ?? "An error occurred while saving the entity changes. See the inner exception for details.");
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return DBActionResult<ApplicationUser>.Failure("An error occurred while saving the entity changes. See the inner exception for details.");
                }
            }
        }

        public async Task<DBActionResult<LoginResponseDto>> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return DBActionResult<LoginResponseDto>.Failure("Invalid email or password");
            }
            return await GetJwtTokenAsync(user);
        }

        public async Task<DBActionResult<LoginResponseDto>> GetJwtTokenAsync(ApplicationUser user)
        {
            var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var jwtToken = GetToken(authClaims);
            var refreshToken = GenerateRefreshToken();

            _logger.LogInformation("JWT Token Created: {Token}", new JwtSecurityTokenHandler().WriteToken(jwtToken)); // Log token
            _logger.LogInformation("JWT Token ValidTo: {ValidTo}", jwtToken.ValidTo); // Log token expiry


            _ = int.TryParse(_configuration["JWT:RefreshTokenValidity"], out int refreshTokenValidity);
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(refreshTokenValidity),
                Secure = true,
                SameSite = SameSiteMode.Strict
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);

            var response = new LoginResponseDto
            {
                AccessToken = new TokenType
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    ExpiryTokenDate = jwtToken.ValidTo
                },
                RefreshToken = new TokenType
                {
                    Token = refreshToken,
                    ExpiryTokenDate = DateTime.UtcNow.AddDays(refreshTokenValidity)
                },
            };

            return new DBActionResult<LoginResponseDto>
            {
                IsSuccess = true,
                Data = response,
                StatusCode = "200"
            };
        }



        public async Task<DBActionResult<LoginResponseDto>> RenewAccessTokenAsync(LoginResponseDto tokens)
        {
            if (tokens == null)
            {
                throw new ArgumentNullException(nameof(tokens));
            }
            var accessToken = tokens.AccessToken;
            var refreshToken = tokens.RefreshToken;
            if (accessToken == null)
            {
                throw new ArgumentNullException(nameof(accessToken));
            }
            if (refreshToken == null)
            {
                throw new ArgumentNullException(nameof(refreshToken));
            }
            var principal = GetClaimsPrincipalFromToken(accessToken.Token);
            if (principal == null)
            {
                return DBActionResult<LoginResponseDto>.Failure("Invalid access token");
            }
            var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return DBActionResult<LoginResponseDto>.Failure("Invalid access token: missing user ID claim");
            }
            var user = await _userManager.FindByIdAsync(userIdClaim.Value);
            if (user == null)
            {
                return DBActionResult<LoginResponseDto>.Failure("User not found");
            }
            if (refreshToken.Token != _httpContextAccessor.HttpContext.Request.Cookies["refreshToken"]
                || refreshToken.ExpiryTokenDate <= DateTime.UtcNow)
            {
                return DBActionResult<LoginResponseDto>.Failure("Invalid or expired refresh token");
            }
            var response = await GetJwtTokenAsync(user);
            return response;
        }

        #region Private Methods
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JWT:TokenValidityInMinutes"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private ClaimsPrincipal GetClaimsPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false
            };
            var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
            return claimsPrincipal;
        }

        public async Task<DBActionResult<IEnumerable<ApplicationUser>>> GetUsers()
        {
            var result = await _unitOfWork.UserRepository.GetAllAsync();
            if (!result.IsSuccess)
            {
                return new DBActionResult<IEnumerable<ApplicationUser>>
                { IsSuccess = false, ErrorMessage = result.ErrorMessage, StatusCode = "400" };

            }
            return new DBActionResult<IEnumerable<ApplicationUser>>
            {
                IsSuccess = true,
                Data = result.Data,
                StatusCode = "200"
            };

        }

        #endregion  
    }
}