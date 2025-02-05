using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions;

public static class IdentityServiceExtension
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var tokenKey = config["TokenKey"] ?? throw new Exception("TokenKey not found");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)), // Chave para validar o token
            ValidateIssuer = false, // Pode ativar se quiser validar o emissor
            ValidateAudience = false, // Pode ativar se quiser validar o público
            // ValidateLifetime = true, // Garante que o token não expirou
            // ClockSkew = TimeSpan.Zero // Remove tolerância no tempo de expiração
        };
    });

        return services;
    }
}
