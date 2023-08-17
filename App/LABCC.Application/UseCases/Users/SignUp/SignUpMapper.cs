using LABCC.Domain.Entities.Users;

namespace LABCC.Application.UseCases.Users.SignUp;

public sealed class SignUpMapper : Mapper<SignUpRequest,SignUpResponse, User>
{
    public override User ToEntity(SignUpRequest r) => 
        User.New(
            r.Email,
            r.Password,
            r.Name,
            r.Document,
            r.DateOfBirth,
            r.Gender,
            r.Phone
        );

    public override SignUpResponse FromEntity(User u) => new()
    {
        Id = u.Id.Value,
        Email = u.Email.Value,
        Document = u.Document.Value,
        Name = u.Name.Value,
        Phone = u.Phone.Value,
        DateOfBirth = u.DateOfBirth.Value,
        Gender = u.Gender.ToString(),
        UserStatus = u.UserStatus.ToString(),
        UserType = u.UserRole.ToString()
    };

}