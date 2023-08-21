using LABCC.Domain.Entities.Users;

namespace LABCC.Application.UseCases.Users;

public class UserEndpointMapper : Mapper<EmptyRequest, UserResponseDto, UserDto>
{
    public override UserResponseDto FromEntity(UserDto u) => new()
    {
        Id = u.Id.ToString(),
        Email = u.Email,
        Document = u.Document,
        Name = u.Name,
        Phone = u.Phone,
        DateOfBirth = DateOnly.FromDateTime(u.DateOfBirth.DateTime),
        Gender = u.Gender.ToString(),
        Status = u.Status.ToString(),
        UserRole = u.UserRole.ToString(),
        CreatedAt = u.CreatedAt,
        UpdatedAt = u.UpdatedAt
    };
}