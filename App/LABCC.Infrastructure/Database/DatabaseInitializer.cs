using System.Data;
using Dapper;
using LABCC.Domain.Interfaces.Database;
using LABCC.Infrastructure.Configs;
using LABCC.Infrastructure.Database.Seed;

namespace LABCC.Infrastructure.Database;

public sealed class DatabaseInitializer
{
    private readonly IDbConnectionFactory _connectionFactory;
    private readonly string _userDbInitialSql;
    private readonly string _root = Directory.GetCurrentDirectory();

    public DatabaseInitializer(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
        _userDbInitialSql = UserInitialSql(_root);
    }

    public async Task InitializeAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(_userDbInitialSql);

        await UserInitialSeed(connection);
    }

    private static string UserInitialSql(string root)
    {
        return File.ReadAllText($"{root}/.sql/UserScript.sql");
    }

    private static async Task UserInitialSeed(IDbConnection connection)
    {
        const string existsQuery = "SELECT TOP 1 1 FROM Users";
        const string insertUserSql = @"
        INSERT INTO Users (Id, Name, Document, DateOfBirth, Gender, Email, UserRole, Phone, Status, Password, CreatedAt, UpdatedAt)
        VALUES (@Id, @Name, @Document, @DateOfBirth, @Gender, @Email, @UserRole, @Phone, @Status, @Password, @CreatedAt, @UpdatedAt)";
        
        var userExist = await connection.ExecuteScalarAsync<bool>(existsQuery);

        if (!userExist) await connection.ExecuteAsync(insertUserSql, UserSeed.Data);
    }
}