using LABCC.Domain.Enums;
using LABCC.Domain.Entities.Users.VO;
using LABCC.Domain.Utils;

namespace LABCC.Domain.Entities.Users;

public sealed class User : BaseEntity
{
    public EmailAddress Email { get; private set; }
    public Password Password { get; private set; }
    public Name Name { get; private set; }
    public Document Document { get; private set; }
    public DateOfBirth DateOfBirth { get; private set; }
    public Gender Gender { get; private set; }
    public Phone Phone { get; private set; }
    public UserRolesEnum UserRole { get; private set;  } = UserRolesEnum.OTHER;

    private User(
        Guid id,
        string email, 
        string password, 
        string name, 
        string document, 
        DateOnly dateOfBirth, 
        string gender, 
        string phone,
        UserRolesEnum rolesEnum,
        DateTimeOffset updatedAt,
        DateTimeOffset createdAt,
        StatusEnum status
        ) : base()
    {
        Id = Identifier.From(id);
        Email = EmailAddress.From(email);
        Name = Name.From(name);
        Phone = Phone.From(phone);
        Document = Document.From(document);
        Password = Password.Hash(password);
        Gender = Gender.From(gender);
        DateOfBirth = DateOfBirth.From(dateOfBirth);
        UserRole = rolesEnum;
        UpdatedAt = updatedAt;
        CreatedAt = createdAt;
        Status = status;
    }

    public static User New(
        string email,
        string password,
        string name,
        string document,
        DateOnly dateOfBirth,
        string gender,
        string phone
    )
    {
        var id = Guid.NewGuid();
        var onlyNumbersDocument = RegexConst.NotNumericalDigit().Replace(document, "");
        var onlyNumbersPhone = RegexConst.NotNumericalDigit().Replace(phone, "");
        const UserRolesEnum role = UserRolesEnum.OTHER;
        var now = DateTimeOffset.Now;
        const StatusEnum status = StatusEnum.ACTIVE;

        return new User(
            id,
            email, 
            password, 
            name, 
            onlyNumbersDocument, 
            dateOfBirth, 
            gender, 
            onlyNumbersPhone,
            role,
            now,
            now,
            status
            );
    }

    public static User New(UserDto dto)
    {
        return new User(
            id: dto.Id,
            document: dto.Document,
            email: dto.Email,
            name: dto.Name,
            password: dto.Password,
            phone: dto.Phone,
            gender: dto.Gender.ToString(),
            rolesEnum: dto.UserRole,
            status: dto.Status,
            updatedAt: dto.UpdatedAt,
            createdAt: dto.CreatedAt,
            dateOfBirth: DateOnly.FromDateTime(dto.DateOfBirth.DateTime)
        );
    }

} 