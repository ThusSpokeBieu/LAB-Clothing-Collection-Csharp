using LABCC.Domain.Interfaces.Repositories;
using LABCC.Domain.Interfaces.Services;

namespace LABCC.Domain.Entities.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;

    public UserService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }
    
    public async Task<bool> CreateAsync(User user)
    {
        /*var existingUser = await _userRepo.GetAsync(user.Id.Value);
        if (existingUser is not null)
        {
            var message = $"A user with id {user.Id} already exists";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(Customer), message)
            });
        }*/

        var userDto = user.ToUserDto();
        return await _userRepo.CreateAsync(userDto);
    }

    public Task<User?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(User customer)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}