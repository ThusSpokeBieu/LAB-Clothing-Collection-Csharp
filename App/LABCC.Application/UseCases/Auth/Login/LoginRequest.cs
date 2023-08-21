using System.ComponentModel;

namespace LABCC.Application.UseCases.Auth.Login;

public sealed record LoginRequest
{
    [DefaultValue("example@email.com")]
    public string Credential { get; init; } = default!;
    
    [DefaultValue("12345678")]
    public string Password { get; init; } = default!;
}