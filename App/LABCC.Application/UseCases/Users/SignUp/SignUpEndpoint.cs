using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LABCC.Application.UseCases.Users.SignUp;

[HttpPost("/api/user/signup")]
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