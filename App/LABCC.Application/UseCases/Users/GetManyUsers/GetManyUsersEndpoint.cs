using LABCC.Application.Security.Auth;
using LABCC.Domain.Entities.Users;
using LABCC.Domain.Enums;
using LABCC.Domain.Interfaces.Services;

namespace LABCC.Application.UseCases.Users.GetManyUsers;

public sealed class GetManyUsersEndpoint : Endpoint<
    GetManyUserQueryParams, 
    IEnumerable<UserResponseDto>, 
    UserEndpointMapper>
{
    private readonly IUserService _userService;

    public GetManyUsersEndpoint(IUserService userService)
    {
        _userService = userService;
    }

    public override void Configure()
    {
        Get("/users");
        Roles(RolesConst.ADMIN, RolesConst.OTHER, RolesConst.CREATOR, RolesConst.MANAGER);
        Options(x => 
            x.CacheOutput(p => 
                p.Expire(TimeSpan.FromSeconds(30))));
    }
    
    public override async Task HandleAsync(GetManyUserQueryParams qp, CancellationToken ct)
    {
        var anGender = Enum.TryParse(qp.Gender, true, out GenderEnum parsedGender);
        var anRole =  Enum.TryParse(qp.Role, true, out UserRolesEnum parsedRole);

        var @params = new UserParams
        {
            Name = qp.Name ?? null,
            
            DateOfBirth = qp.DateOfBirth is not null ? 
                new DateTimeOffset(qp.DateOfBirth.Value, TimeOnly.MinValue, TimeSpan.Zero) : 
                null,
            
            Gender = anGender ? parsedGender : null,
            UserRole = anRole ? parsedRole : null,
        };

        var data = await _userService.GetAllAsync(qp.Page, @params);
        Response = data.Select(x => Map.FromEntity(x));
        
        await SendAsync(Response, 200, ct);
    }
}