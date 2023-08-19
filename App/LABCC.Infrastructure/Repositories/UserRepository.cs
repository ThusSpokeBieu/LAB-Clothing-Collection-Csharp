using System.Data;
using Dapper;
using LABCC.Domain.Entities.Users;
using LABCC.Domain.Enums;
using LABCC.Domain.Interfaces.Database;
using LABCC.Domain.Interfaces.Repositories;
using LABCC.Infrastructure.Repositories.Sql;

namespace LABCC.Infrastructure.Repositories;

public sealed class UserRepository : IUserRepository
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

    public async Task<UserDto?> UserLogin(string credential)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        
        var parameters = new
        {
            LoginValue = credential
        };
        
        return await connection.QueryFirstOrDefaultAsync<UserDto>(
            UserProcedures.UserLogin,
            parameters,
            commandType: CommandType.StoredProcedure);

    }

    public async Task<UserDto?> GetAsync(string? @param)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        var parameters = new
        {
            SearchValue = @param,
            Status = StatusEnum.ACTIVE
        };

        return await connection.QueryFirstOrDefaultAsync<UserDto>(
            UserProcedures.GetSingleUser,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync(int page, UserParams? @params)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        var parameters = new
        {
            PageNumber = page,
            PageSize = 20,
            FilterName = @params?.Name ?? null,
            FilterGender = @params?.Gender ?? null,
            FilterStatus = @params?.Status ?? null,
            FilterUserRole = @params?.UserRole ?? null,
            FilterDateOfBirth = @params?.DateOfBirth ?? null,
        };

        return await connection.QueryAsync<UserDto>(
            UserProcedures.GetUsersByPage, 
            parameters,
            commandType: CommandType.StoredProcedure);
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