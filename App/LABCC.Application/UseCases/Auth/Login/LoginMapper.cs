
using LABCC.Application.UseCases.Auth.SignUp;
using LABCC.Domain.Entities.Users;

namespace LABCC.Application.UseCases.Auth.Login;

public class LoginMapper : IMapper
{
    public static LoginResponse FromEntity(UserDto data, string token) => new()
    {
        Id = data.Id.ToString(),
        Document = data.Document,
        Email = data.Email, 
        Name = data.Name,
        Phone = data.Phone,
        UserRole = data.UserRole.ToString(),
        Token = token
    };

}