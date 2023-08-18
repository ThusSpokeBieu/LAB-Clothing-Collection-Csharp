using LABCC.Domain.Interfaces.Services;
using LABCC.Infrastructure.Configs;
using Microsoft.AspNetCore.Authorization;
using Claim = System.Security.Claims.Claim;
using ClaimConst = LABCC.Application.Configs.Auth.Claim;

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

        var jwtToken = JWTBearer.CreateToken(
            signingKey: CustomConfig.FromEnv()["Jwt-Secret"]!,
            expireAt: DateTime.UtcNow.AddDays(1),
            permissions: new []{ "200", "201", "202", "203", "204"},
        claims: new Claim[]
            {
                new(ClaimConst.Id, data!.Id.ToString()), 
                new(ClaimConst.Document, data.Document), 
                new(ClaimConst.Name, data.Name),
                new(ClaimConst.userRole, data.UserRole.ToString())
            }
        );

        Response = LoginMapper.FromEntity(data, jwtToken);
        
        await SendAsync(Response, 201, ct);
    }
}