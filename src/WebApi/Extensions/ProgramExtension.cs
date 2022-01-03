using Microsoft.AspNetCore.Authentication;
using WebApi.Authorization;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Extensions;

public static class ProgramExtensions
{
    public static void SetupServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddControllers();

        builder.Services.AddRouting(options => options.LowercaseUrls = true);

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy(nameof(PermissionType.GetWeatherForecast), 
                policy => policy.RequireClaim("permission", nameof(PermissionType.GetWeatherForecast)));
        });

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddAuthenticationExtension(builder.Configuration);

        builder.Services.AddSwaggerExtension(builder.Configuration);

        builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

        builder.Services.AddScoped<IClaimsTransformation, AddPermissionsClaimsTransformation>();
    }

    public static void SetupRequestPipeline(this WebApplication app)
    {
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseSwaggerExtension(app.Configuration);

        app.MapControllers().RequireAuthorization();
    }
}
