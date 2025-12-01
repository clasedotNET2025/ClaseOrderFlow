using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using OrderFlowClase.ApiGateway.Extensions;
using RedisRateLimiting;
using StackExchange.Redis;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Configuration.AddUserSecrets(typeof(Program).Assembly, true);

builder.AddRedisClient("redis");

builder.Services.AddYarpReverseProxy(builder.Configuration);

builder.Services.AddRateLimiter(rateLimiterOptions =>
{

    // open policy for public endpoints (100 req/min)
    rateLimiterOptions.AddPolicy("open", context =>
    {
        var redis = context.RequestServices.GetRequiredService<IConnectionMultiplexer>();
        var ipAddress = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";

        return RedisRateLimitPartition.GetFixedWindowRateLimiter(
            $"ip:{ipAddress}",
            _ => new RedisFixedWindowRateLimiterOptions
            {
                ConnectionMultiplexerFactory = () => redis,
                PermitLimit = 100,
                Window = TimeSpan.FromMinutes(1)
            });
    });
});

builder.Services.AddGatewayCors();

builder.AddServiceDefaults();

builder.Services.AddOpenApi();

builder.Services.AddAuthentication();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration.GetSection("JWT:Issuer").Value,
                ValidAudience = builder.Configuration.GetSection("JWT:Audience").Value,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JWT:SecretKey").Value!))
            };
        });

builder.Services.AddOpenApi();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthentication(); // IMPORTANTE <- PARA PODER AUTENTICAR

app.UseAuthorization();

app.UseRateLimiter();

app.MapReverseProxy();

//app.MapControllers();

app.Run();
