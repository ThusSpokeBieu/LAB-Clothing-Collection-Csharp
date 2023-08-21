using LABCC.Application.Security.Auth;
using LABCC.Domain.Interfaces.Services;

namespace LABCC.Application.UseCases.Users.UpdateUser;

public class UpdateUserEndpoint : Endpoint<
    UpdateUserRequest,
    EmptyResponse>
{
    private readonly IUserService _userService;

    public UpdateUserEndpoint(IUserService userService)
    {
        _userService = userService;
    }
    
    public override void Configure()
    {
        Put("/users/{Id}");
        Roles(RolesConst.ADMIN, RolesConst.OTHER, RolesConst.CREATOR, RolesConst.MANAGER);
        Options(x => 
            x.CacheOutput(p => 
                p.Expire(TimeSpan.FromSeconds(30))));
        
    }
    
    public override async Task HandleAsync(UpdateUserRequest @param, CancellationToken ct)
    {
        await Task.CompletedTask; 
        AddError("Not implemented");
        
        ThrowIfAnyErrors();
    }
    
    
}