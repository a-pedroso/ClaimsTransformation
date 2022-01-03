namespace WebApi.Authorization;

using Microsoft.AspNetCore.Authorization;

public class AuthorizePermissionAttribute : AuthorizeAttribute
{
    public AuthorizePermissionAttribute(string permission)
        : base(permission)
    {

    }
}
