namespace LABCC.Application.UseCases.Auth.Login;

public record LoginResponse
{
    public string Id { get; init; } = default!;
    public string Document { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Phone { get; init; } = default!;
    public string UserRole { get; init; } = default!;
    public string Token { get; init; } = default!;
}