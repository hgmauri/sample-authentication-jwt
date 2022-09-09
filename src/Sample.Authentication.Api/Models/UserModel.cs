namespace Sample.Authentication.Api.Models;

public record UserModel
{
    public Guid Id { get; set; }
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Role { get; set; } = default!;
    public bool IsActive { get; set; }
    public bool PaidUser { get; set; }
}
