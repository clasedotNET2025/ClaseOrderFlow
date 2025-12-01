using Microsoft.AspNetCore.Identity.Data;
using OrderFlowClase.API.Identity.Services;

namespace OrderFlowClase.API.Identity.MinimalControllers
{
    public static class Auth
    {
        public static RouteHandlerBuilder AddRegisterEndpoints(this IEndpointRouteBuilder routeBuilder)
        {
            return routeBuilder.MapPost("/api/v2/auth/register", async (
                IAuthService authService,
                RegisterRequest request) =>
            {
                var result = await authService.Register(request.Email, request.Password);
                if (!result)
                {
                    return Results.BadRequest(new { Message = "User registration failed." });
                }
                return Results.Ok(new { Message = "User registered successfully." });
            });
        }

        public static RouteHandlerBuilder AddLoginEndpoints(this IEndpointRouteBuilder routeBuilder)
        {
            return routeBuilder.MapPost("/api/v2/auth/login", async (
                IAuthService authService,
                LoginRequest request) =>
            {
                var response = await authService.Login(request.Email, request.Password);
                if (response == null)
                {
                    return Results.Unauthorized();
                }
                return Results.Ok(response);
            });
        }
    }
}
