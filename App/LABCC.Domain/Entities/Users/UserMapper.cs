namespace LABCC.Domain.Entities.Users;

public static class UserMapper
{
    public static UserDto ToUserDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id.Value.ToString(),
            Email = user.Email.Value,
            Password = user.Password.Value,
            Document = user.Document.Value,
            Name = user.Name.Value,
            Phone = user.Phone.Value,
            DateOfBirth = user.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue),
            Gender = user.Gender.Value,
            Status = user.Status,
            UserRole = user.UserRole,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }
}