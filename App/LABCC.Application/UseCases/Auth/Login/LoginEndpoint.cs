using LABCC.Application.Security.Auth;
using LABCC.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace LABCC.Application.UseCases.Auth.Login;

[HttpPost("/auth/login"), AllowAnonymous]
public sealed class LoginEndpoint : Endpoint<
    LoginRequest,
    LoginResponse,
    LoginMapper>
{
    private readonly IUserService _userService;

    public LoginEndpoint(IUserService userService)
    {
        _userService = userService;
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        var data = await _userService.UserLogin(req.Credential, req.Password);
        if (data is null) AddError("Credentials are invalid or password don't match");
        
        ThrowIfAnyErrors();

        var jwtToken = JwtBuilder.New(data!);

        Response = LoginMapper.FromEntity(data!, jwtToken);
        
        await SendAsync(Response, 201, ct);
    }
}