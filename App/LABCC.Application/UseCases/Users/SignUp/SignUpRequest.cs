namespace LABCC.Application.UseCases.Users.SignUp;

public sealed class SignUpRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public string Gender { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Phone { get; set; }
}