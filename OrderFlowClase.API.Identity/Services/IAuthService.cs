using Microsoft.AspNetCore.Identity;
using OrderFlowClase.API.Identity.Dto.Auth;

namespace OrderFlowClase.API.Identity.Services
{
    public interface IAuthService
    {
        Task<RegisterResult> Register(string email, string password);
        Task<ResponseLogin?> Login(string email, string password);
    }

    public class RegisterResult
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; } = Array.Empty<string>();
    }
}
