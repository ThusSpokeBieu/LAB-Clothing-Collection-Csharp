namespace LABCC.Infrastructure.Configs;

public class ConnectionString
{
    public static string FromEnv()
    {
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
        var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        var dbUser = Environment.GetEnvironmentVariable("DB_USER");
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
        
        var connectionString = $"Server={dbHost},{dbPort};Database={dbName};User Id={dbUser};Password={dbPassword};Trusted_Connection=False;TrustServerCertificate=true;MultipleActiveResultSets=true";

        return connectionString;
    }
}