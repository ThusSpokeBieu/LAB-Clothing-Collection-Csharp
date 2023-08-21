using FluentValidation.Results;
using LABCC.Application.Security.Auth;
using LABCC.Domain.Interfaces.Services;

namespace LABCC.Application.UseCases.Users.GetSingleUser;

public class GetSingleUserEndpoint : Endpoint<
    GetSingleUserRouteParams, 
    UserResponseDto, 
    UserEndpointMapper>
{
    private readonly IUserService _userService;

    public GetSingleUserEndpoint(IUserService userService)
    {
        _userService = userService;
    }

    public override void Configure()
    {
        Get("/users/{SearchParam}");
        Roles(RolesConst.ADMIN, RolesConst.OTHER, RolesConst.CREATOR, RolesConst.MANAGER);
        Options(x => 
            x.CacheOutput(p => 
                p.Expire(TimeSpan.FromSeconds(30))));
        
    }
    
    public override async Task HandleAsync(GetSingleUserRouteParams @param, CancellationToken ct)
    {
        var data = await _userService.GetAsync(@param.SearchParam);
        
        if (data is null) AddError("User with provided param was not found");
        
        ThrowIfAnyErrors();
        
        Response = Map.FromEntity(data!);
        
        await SendAsync(Response, 200, ct);
    }
}