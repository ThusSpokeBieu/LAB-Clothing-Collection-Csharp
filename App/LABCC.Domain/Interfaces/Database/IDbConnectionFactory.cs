using System.Data;

namespace LABCC.Domain.Interfaces.Database;

public interface IDbConnectionFactory
{
    public Task<IDbConnection> CreateConnectionAsync();
}