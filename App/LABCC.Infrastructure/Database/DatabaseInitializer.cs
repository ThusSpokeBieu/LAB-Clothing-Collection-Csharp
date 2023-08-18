using Dapper;
using LABCC.Domain.Interfaces.Database;

namespace LABCC.Infrastructure.Database;

public class DatabaseInitializer
{
    private readonly IDbConnectionFactory _connectionFactory;
    private readonly string _userDbInitialSql;

    public DatabaseInitializer(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
        _userDbInitialSql = UserInitialSql();
    }

    public async Task InitializeAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(_userDbInitialSql);
    }

    private static string UserInitialSql()
    {
        return File.ReadAllText("./../../Resources/UserScript.sql");
    }
}