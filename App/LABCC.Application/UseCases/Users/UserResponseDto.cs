namespace LABCC.Application.UseCases.Users;

public sealed record UserResponseDto
{
    public string Id { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Document { get; init; } = default!; 
    public DateOnly DateOfBirth { get; init; } = default!;
    public string Gender { get; init; } = default!;
    public string Phone { get; init; } = default!;
    public string UserRole { get; init; } = default!;
    public DateTimeOffset UpdatedAt { get; init; } = default!;
    public DateTimeOffset CreatedAt { get; init; } = default!;
    public string Status { get; init; } = default!;
}