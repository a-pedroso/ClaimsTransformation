using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class IdentityController : ControllerBase
{
    /// <summary>
    /// Get Authenticated User Claims
    /// </summary>
    /// <returns>JSON with user claims</returns>
    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
    }
}
