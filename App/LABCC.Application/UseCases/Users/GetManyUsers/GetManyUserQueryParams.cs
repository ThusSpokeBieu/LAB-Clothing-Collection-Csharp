using System.ComponentModel.DataAnnotations;

namespace LABCC.Application.UseCases.Users.GetManyUsers;

public sealed record GetManyUserQueryParams
{
    [QueryParam]
    public int Page { get; init; } = 1;
    
    [QueryParam]
    public string? Name { get; init; } = default!;
    
    [QueryParam]
    public DateOnly? DateOfBirth { get; init; } = default!;
    
    [QueryParam]
    public string? Gender { get; init; } = default!;
    
    [QueryParam]
    public string? Role { get; init; } = default!;
}