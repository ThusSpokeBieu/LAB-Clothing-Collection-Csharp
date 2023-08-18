using System.ComponentModel;

namespace LABCC.Application.UseCases.Auth.SignUp;

public sealed record SignUpRequest
{
    [DefaultValue("example@email.com")]
    public string Email { get; init; } = default!;
    
    [DefaultValue("12345678")]
    public string Password { get; init; } = default!;
    
    [DefaultValue("John Doe")]
    public string Name { get; init; } = default!;
    
    [DefaultValue("323.229.592-43")]
    public string Document { get; init; } = default!;
    
    [DefaultValue("Other")]
    public string Gender { get; init; } = default!;
    
    [DefaultValue("1979-03-10")]
    public DateOnly DateOfBirth { get; init; } = default!;
    
    [DefaultValue("(86) 99741-9303")]
    public string Phone { get; init; } = default!;
}