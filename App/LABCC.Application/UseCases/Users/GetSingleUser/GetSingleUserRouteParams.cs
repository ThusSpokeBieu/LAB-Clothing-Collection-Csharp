using Microsoft.AspNetCore.Mvc;

namespace LABCC.Application.UseCases.Users.GetSingleUser;

public record GetSingleUserRouteParams
{
    
    [FromRoute]
    public string SearchParam { get; init; } = default!;
};