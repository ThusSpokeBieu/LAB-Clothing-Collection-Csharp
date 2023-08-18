using LABCC.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace LABCC.Application.UseCases.Auth.SignUp;

[HttpPost("/auth/signup"), AllowAnonymous]
public sealed class SignUpEndpoint : Endpoint<
    SignUpRequest, 
    SignUpResponse, 
    SignUpMapper>
{
    private readonly IUserService _userService;
    
    public SignUpEndpoint(IUserService userService)
    {
        _userService = userService;
    }
    
    public override async Task HandleAsync(SignUpRequest req, CancellationToken ct)
    {
        var user = Map.ToEntity(req);

        var result = await _userService.CreateAsync(user);

        if (!result) AddError(r => r.Document, "Something was wrong");

        ThrowIfAnyErrors();
        
        Response = Map.FromEntity(user);

        await SendAsync(Response, 201, ct);
    }

}