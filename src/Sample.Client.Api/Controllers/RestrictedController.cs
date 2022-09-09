using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sample.Client.Api.Controllers;

[ApiController]
[Route("restricted")]
public class RestrictedController : ControllerBase
{
    [HttpGet("anonymous")]
    [AllowAnonymous]
    public IActionResult Anonymous() =>
        Ok(new { message = "Anonymous Public Endpoint" });

    [HttpGet("authenticated")]
    [Authorize]
    public IActionResult Authenticated() =>
        Ok(new { message = $"Authenticated endpoint. Hi {User?.Identity?.Name} =)" });

    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminAccess() =>
        Ok(new { message = $"Admin endpoint. Hi {User?.Identity?.Name} =)" });
}
