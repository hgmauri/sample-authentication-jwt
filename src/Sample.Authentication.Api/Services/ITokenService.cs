using Sample.Authentication.Api.Models;

namespace Sample.Authentication.Api.Services;

public interface ITokenService
{
    string GenerateToken(UserModel user);
}
