using Microsoft.AspNetCore.Mvc;
using Sample.Authentication.Api.Models;
using Sample.Authentication.Api.Services;

namespace Sample.Authentication.Api.Controllers;

[ApiController]
[Route("authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public AuthenticationController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost]
    public IActionResult RequestToken(RequestToken request)
    {
        var user = GetUser(request.Username, request.Password);

        if (user is null)
            return NotFound(new { message = "User not found" });

        var token = _tokenService.GenerateToken(user);

        return Ok(new
        {
            token
        });
    }

    private UserModel? GetUser(string username, string password)
    {
        return new UserModel { Username = username, Password = password };
    }
}
