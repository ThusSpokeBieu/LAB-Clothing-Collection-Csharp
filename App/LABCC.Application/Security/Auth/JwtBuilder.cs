using System.Security.Claims;
using LABCC.Domain.Entities.Users;
using LABCC.Infrastructure.Configs;

namespace LABCC.Application.Security.Auth;

public static class JwtBuilder
{
    public static string New(UserDto data) =>
        JWTBearer.CreateToken(
                signingKey: CustomConfig.FromEnv()["Jwt-Secret"]!,
                expireAt: DateTime.UtcNow.AddDays(1),
                permissions: new []{ $"{data.UserRole}" },
                claims: SetClaims(data)
            );

    private static IEnumerable<Claim> SetClaims(UserDto data) =>
        new Claim[]
        {
            new(ClaimConst.Id, data!.Id.ToString()),
            new(ClaimConst.Document, data.Document),
            new(ClaimConst.Name, data.Name),
            new(ClaimConst.userRole, data.UserRole.ToString())
        };
}