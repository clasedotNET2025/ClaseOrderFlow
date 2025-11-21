using Microsoft.AspNetCore.Identity;
using OrderFlowClase.API.Identity.DTOs.Auth;

namespace OrderFlowClase.API.Identity.Services
{
    public interface IAuthService
    {
        Task<bool> Register(string username, string password);
        Task<ResponseLogin> Login(string username, string password);
    }
}
