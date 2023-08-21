using LABCC.Domain.Entities.Users;

namespace LABCC.Domain.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<UserDto, UserParams>
{
    public Task<UserDto?> UserLogin(string credential);
}