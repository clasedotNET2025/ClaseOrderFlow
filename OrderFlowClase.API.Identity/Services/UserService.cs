using FluentValidation;
using Microsoft.AspNetCore.Identity;
using OrderFlowClase.API.Identity.Dto.Users;

namespace OrderFlowClase.API.Identity.Services
{
    public class UserService :IUserService
    {
        private UserManager<IdentityUser> _userManager;
        private readonly ILogger<UserService> _logger;
        //private readonly IValidator<PasswordChangeRequestValidator> _passwordChangeValidator;

        public UserService(
            UserManager<IdentityUser> userManager, 
            ILogger<UserService> logger)
        {
            _userManager = userManager;
            _logger = logger;
            //_passwordChangeValidator = passwordChangeValidator;

        }

        public async Task<bool> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            //var result = _passwordChangeValidator.ValidateAsync();

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                _logger.LogWarning("User with ID {UserId} not found.", userId);
                return false;
            }

            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    _logger.LogWarning("Error changing password for user {UserId}: {Error}", userId, error.Description);
                }
                return false;
            }

            _logger.LogInformation("Password changed successfully for user {UserId}.", userId);
            
            return true;
        }
    }
}
