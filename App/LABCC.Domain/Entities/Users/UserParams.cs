using System.Data;
using LABCC.Domain.Enums;

namespace LABCC.Domain.Entities.Users;

public sealed record UserParams
{
    public string? Name { get; init; } = null;
    public DateTimeOffset? DateOfBirth { get; init; } = null;
    public GenderEnum? Gender { get; init; } = null;
    public UserRolesEnum? UserRole { get; init; } = null;
    public StatusEnum? Status { get; init; } = null;

}