namespace LABCC.Infrastructure.Configs;

public static class CustomConfig
{
    public static Dictionary<string, string> FromEnv()
    {
        var appRoot = Directory.GetCurrentDirectory();

        DotEnv.Load($"{appRoot}/../../.env");
        var connectionString = GetConnectionString();
        var jwtSecret = GetJwtSecret();

        return new Dictionary<string, string>
        {
            { "Connection-String", connectionString },
            { "Jwt-Secret", jwtSecret }
        };
    }

    private static string GetConnectionString()
    {
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        var dbName = Environment.GetEnvironmentVariable("DB_NAME");
        var dbUser = Environment.GetEnvironmentVariable("DB_USER");
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
        
        var connectionString = $"Server={dbHost};Database={dbName};User Id={dbUser};Password={dbPassword};Trusted_Connection=False;TrustServerCertificate=true;MultipleActiveResultSets=true";

        return connectionString;
    }

    private static string GetJwtSecret()
    {
        return Environment.GetEnvironmentVariable("JWT_SECRET")!;
    }

}