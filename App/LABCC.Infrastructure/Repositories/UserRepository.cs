using System.Data;
using Dapper;
using LABCC.Domain.Entities.Users;
using LABCC.Domain.Interfaces.Database;
using LABCC.Domain.Interfaces.Repositories;
using LABCC.Infrastructure.Repositories.Sql;

namespace LABCC.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public UserRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    
    public async Task<bool> CreateAsync(UserDto user)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            UserProcedures.Insert, 
            user,
            commandType: CommandType.StoredProcedure);
        
        return result > 0;
    }

    public Task<UserDto?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDto>> GetAllAsync(int page)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(UserDto customer)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}