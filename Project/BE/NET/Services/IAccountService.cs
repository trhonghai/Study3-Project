using System.IdentityModel.Tokens.Jwt;
using NET.Data;
using NET.Data.Providers.Models;
using NET.Dto;
using NET.GenericRepository;

namespace NET.Services
{
    public interface IAccountService
    {
        Task<DBActionResult<ApplicationUser>> CreateUserAsync(RegisterDto registerDto);
        // Task<DBActionResult<ApplicationUser>> GetUserByIdAsync(string userId);
        // Task<DBActionResult<ApplicationUser>> UpdateUserAsync(ApplicationUser user);
        // Task<DBActionResult<bool>> DeleteUserAsync(string userId);
        // Task<DBActionResult<IEnumerable<ApplicationUser>>> GetAllUsersAsync();
        Task<DBActionResult<LoginResponseDto>> LoginAsync(LoginDto loginDto);
        Task<DBActionResult<LoginResponseDto>> RenewAccessTokenAsync(LoginResponseDto tokens);
        Task<DBActionResult<LoginResponseDto>> GetJwtTokenAsync(ApplicationUser user);

        Task<DBActionResult<IEnumerable<ApplicationUser>>> GetUsers();
    }
}
