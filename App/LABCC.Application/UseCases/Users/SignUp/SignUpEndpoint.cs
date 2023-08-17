using Microsoft.AspNetCore.Authorization;

namespace LABCC.Application.UseCases.Users.SignUp;

[HttpPost("/users/signup")]
[AllowAnonymous]
public sealed class SignUpEndpoint : Endpoint<
    SignUpRequest, 
    SignUpResponse, 
    SignUpMapper>
{
    public override async Task HandleAsync(SignUpRequest req, CancellationToken ct)
    {
        var user = Map.ToEntity(req);
        Response = Map.FromEntity(user);
        await SendAsync(Response);
    }

}