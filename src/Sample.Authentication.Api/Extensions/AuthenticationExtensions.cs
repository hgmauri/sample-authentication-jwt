using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Sample.Authentication.Api.Models;

namespace Sample.Authentication.Api.Extensions;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddAuthentications(this IServiceCollection services, IConfiguration configuration)
    {
        var optionsConfig = new JwtSettings();
        configuration.GetSection(nameof(JwtSettings)).Bind(optionsConfig);

        var key = Encoding.UTF8.GetBytes(optionsConfig?.SecretKey);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        return services;
    }
}
