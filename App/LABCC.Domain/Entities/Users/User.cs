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
        string email, 
        string password, 
        string name, 
        string document, 
        DateOnly dateOfBirth, 
        string gender, 
        string phone
        ) : base()
    {
        Email = EmailAddress.From(email);
        Name = Name.From(name);
        Phone = Phone.From(phone);
        Document = Document.From(document);
        Password = Password.Hash(password);
        Gender = Gender.From(gender);
        DateOfBirth = DateOfBirth.From(dateOfBirth);
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
        var onlyNumbersDocument = RegexConst.NotNumericalDigit().Replace(document, "");
        
        return new User(
            email, 
            password, 
            name, 
            onlyNumbersDocument, 
            dateOfBirth, 
            gender, 
            phone
            );
    }


} 