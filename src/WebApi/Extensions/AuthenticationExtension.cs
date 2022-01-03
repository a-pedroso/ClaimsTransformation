using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApi.Extensions;

public static class AuthenticationExtension
{
    public static IServiceCollection AddAuthenticationExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer("Bearer", options =>
        {
            options.Authority = configuration.GetValue<string>("Authentication:Jwt:Authority");
            options.RequireHttpsMetadata = configuration.GetValue<bool>("Authentication:Jwt:RequireHttpsMetadata");
            options.Audience = configuration.GetValue<string>("Authentication:Jwt:Audience");
        });

        return services;
    }
}
