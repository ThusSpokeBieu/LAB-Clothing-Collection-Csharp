using LABCC.Domain.Entities.Users;

namespace LABCC.Domain.Interfaces.Services;

public interface IUserService : IBaseService<User, UserDto, UserParams>
{

    public Task<UserDto?> UserLogin(string credential, string password);

}