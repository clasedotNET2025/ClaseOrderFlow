using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OrderFlowClase.API.Identity.DTOs.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace OrderFlowClase.API.Identity.Services
{
    public class AuthService : IAuthService
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            
            _roleManager = roleManager;

            _configuration = configuration;
        }

        public async Task<ResponseLogin?> Login(string username, string password)
        {
            var user = await _userManager.FindByEmailAsync(username);
            
            if (user == null)
            {
                return null;
            }

            var result = await _userManager.CheckPasswordAsync(user, password);

            if(!result)
            {
                return null;
            }
            
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<System.Security.Claims.Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, roles.FirstOrDefault() ?? "NoRole")
            };

            var secretKey = _configuration["JwtSettings:SecretKey"];
            var audience = _configuration["JwtSettings:Audience"];
            var issuer = _configuration["JwtSettings:Issuer"];
            var expirationMinutes = int.Parse(_configuration["JwtSettings:expirationMinutes"]!);

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddMinutes(expirationMinutes),
                signingCredentials: creds
            );

            var encryptedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new ResponseLogin
            {
                Token = encryptedToken,
                ExpirationAtUtc = DateTime.UtcNow.AddMinutes(expirationMinutes)
            };

        }

        public async Task<bool> Register(string username, string password)
        {
            var result = await _userManager.CreateAsync(new IdentityUser
            {
                UserName = username.Split("@")[0],
                Email = username
            }, password);

            return true;
        }
    }
}
