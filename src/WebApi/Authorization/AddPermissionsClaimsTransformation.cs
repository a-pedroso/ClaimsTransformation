using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using WebApi.Services;

namespace WebApi.Authorization;

// adapted from here -> https://gunnarpeipman.com/aspnet-core-adding-claims-to-existing-identity/
// also check this link -> https://docs.microsoft.com/en-us/aspnet/core/security/authentication/claims?view=aspnetcore-6.0
public class AddPermissionsClaimsTransformation : IClaimsTransformation
{
    private readonly ICurrentUserService _userService;

    public AddPermissionsClaimsTransformation(ICurrentUserService userService)
    {
        _userService = userService;
    }

    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        ClaimsIdentity claimsIdentity = new();

        // Support AD and local accounts
        var nameId = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier ||
                                                          c.Type == ClaimTypes.Name);
        if (nameId == null)
        {
            return principal;
        }

        // Get user from database
        var user = await _userService.GetByUserName(nameId.Value);
        if (user == null)
        {
            return principal;
        }

        // Add permissions claims to identity
        foreach (var permission in user.Permissions)
        {
            var claim = new Claim("permission", permission.Name);
            claimsIdentity.AddClaim(claim);
        }

        principal.AddIdentity(claimsIdentity);

        return principal;
    }
}