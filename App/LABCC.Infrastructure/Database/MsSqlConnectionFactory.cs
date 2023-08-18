using System.Data;
using System.Data.SqlClient;
using LABCC.Domain.Interfaces.Database;

namespace LABCC.Infrastructure.Database;

public class MsSqlConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;
    
    public MsSqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public async Task<IDbConnection> CreateConnectionAsync()
    {
        var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        return connection;
    }
}