using System.ComponentModel;

namespace LABCC.Application.UseCases.Users.SignUp;

public sealed class SignUpRequest
{
    [DefaultValue("example@email.com")]
    public string Email { get; set; }
    
    [DefaultValue("12345678")]
    public string Password { get; set; }
    
    [DefaultValue("John Doe")]
    public string Name { get; set; }
    
    [DefaultValue("323.229.592-43")]
    public string Document { get; set; }
    
    [DefaultValue("Other")]
    public string Gender { get; set; }
    
    [DefaultValue("1979-03-10")]
    public DateOnly DateOfBirth { get; set; }
    
    [DefaultValue("(86) 99741-9303")]
    public string Phone { get; set; }
}