namespace LABCC.Infrastructure.Repositories.Sql;

public sealed record UserProcedures
{
    public const string Insert = "dbo.InsertUser";
    public const string GetUsersByPage = "dbo.GetUsersByPage";
    public const string GetSingleUser = "dbo.GetSingleUser";
    public const string UserLogin = "dbo.UserLogin";
}