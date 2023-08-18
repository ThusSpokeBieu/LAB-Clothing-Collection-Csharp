using LABCC.Domain.Entities.Users;
using LABCC.Domain.Enums;
using LABCC.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace LABCC.Application.UseCases.Users.GetManyUsers;

[HttpGet("/users/list"), AllowAnonymous]
public sealed class GetManyUsersEndpoint : EndpointWithoutRequest<IEnumerable<UserDto>>
{
    private readonly IUserService _userService;

    public GetManyUsersEndpoint(IUserService userService)
    {
        _userService = userService;
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var page = Query<int?>("page", isRequired: false) ?? 1;
        var name = Query<string>("string", isRequired: false);
        var dateOfBirth = Query<DateTime?>("dateOfBirth", isRequired: false);
        var gender = Query<string>("gender", isRequired: false);
        var role = Query<string>("Role", isRequired: false);

        var anGender = Enum.TryParse(gender, true, out GenderEnum parsedGender);
        var anRole =  Enum.TryParse(role, true, out UserRolesEnum parsedRole);

        var @params = new UserParams
        {
            Name = name ?? null,
            DateOfBirth = dateOfBirth ?? null,
            Gender = anGender ? parsedGender : null,
            UserRole = anRole ? parsedRole : null,
        };

        Response = await _userService.GetAllAsync(page, @params);

        await SendAsync(Response, 200, ct);
    }
}