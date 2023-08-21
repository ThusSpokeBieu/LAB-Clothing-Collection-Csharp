using LABCC.Domain.Enums;

namespace LABCC.Application.Security.Auth;

public sealed record RolesConst
{
    public const string ADMIN = "ADMIN";
    public const string MANAGER = "MANAGER";
    public const string CREATOR = "CREATOR";
    public const string OTHER = "OTHER";
}