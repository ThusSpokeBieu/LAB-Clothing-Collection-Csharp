namespace LABCC.Application.UseCases.Auth.SignUp;

public sealed record SignUpResponse
{
    public Guid Id { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Document { get; init; } = default!;
    public string Gender { get; init; } = default!;
    public DateOnly DateOfBirth { get; init; } = default!;
    public string Phone { get; init; } = default!;
    public string UserType { get; init; } = default!;
    public string UserStatus { get; init; } = default!;
}