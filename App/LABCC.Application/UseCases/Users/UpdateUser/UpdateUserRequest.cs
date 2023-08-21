using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LABCC.Application.UseCases.Users.UpdateUser;

public sealed record UpdateUserRequest
{
    [FromRoute]
    [JsonIgnore]
    public Guid Id { get; init; } = default!;
    
    public string Email { get; init; } = default!;
    public string Password { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Document { get; init; } = default!; 
    public DateOnly DateOfBirth { get; init; } = default!;
    public string Gender { get; init; } = default!;
    public string Phone { get; init; } = default!;
    public string UserRole { get; init; } = default!;
}