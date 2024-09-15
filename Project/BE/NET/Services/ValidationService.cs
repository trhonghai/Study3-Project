using Microsoft.AspNetCore.Identity;
using NET.Data;
using NET.Dto;
using System.ComponentModel.DataAnnotations;

namespace NET.Services
{
    public class ValidationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ValidationService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> ValidateRegisterDtoAsync(RegisterDto registerDto)
        {
            var emailExists = await _userManager.FindByEmailAsync(registerDto.Email) != null;
            var phoneNumberExists = _userManager.Users.Any(u => u.PhoneNumber == registerDto.PhoneNumber);
            if (emailExists)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Email already exists." });
            }
            if (phoneNumberExists)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Phone number already exists." });
            }
            return IdentityResult.Success;
        }
    }
}
