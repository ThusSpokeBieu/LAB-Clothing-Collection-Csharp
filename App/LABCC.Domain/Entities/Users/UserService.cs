using LABCC.Domain.Entities.Users.VO;
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

    public async Task<UserDto?> UserLogin(string credential, string password)
    {
        var userDto = await _userRepo.UserLogin(credential);

        if (userDto is null) return userDto;

        var isValid = Password.Verify(userDto.Password, password);

        return isValid ? userDto : null;
    }

    public async Task<UserDto?> GetAsync(string param)
    {
        return await _userRepo.GetAsync(@param);
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync(int page, UserParams @params)
    {
        return await _userRepo.GetAllAsync(page, @params);
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