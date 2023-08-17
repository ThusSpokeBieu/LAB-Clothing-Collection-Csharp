namespace LABCC.Application.UseCases.Users.SignUp;

public sealed class SignUpResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public string Gender { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Phone { get; set; }
    public string UserType { get; set; }
    public string UserStatus { get; set; }
}