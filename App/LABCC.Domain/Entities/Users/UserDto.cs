using System.Text.Json.Serialization;
using LABCC.Domain.Enums;

namespace LABCC.Domain.Entities.Users;

public sealed record UserDto
{
    public Guid Id { get; init; } = default!;
    public string Email { get; init; } = default!;
    
    [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
    public string Password { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Document { get; init; } = default!; 
    public DateTimeOffset DateOfBirth { get; init; } = default!;
    public GenderEnum Gender { get; init; } = default!;
    public string Phone { get; init; } = default!;
    public UserRolesEnum UserRole { get; init; } = default!;
    public DateTimeOffset UpdatedAt { get; init; } = default!;
    public DateTimeOffset CreatedAt { get; init; } = default!;
    public StatusEnum Status { get; init; } = default!;
}