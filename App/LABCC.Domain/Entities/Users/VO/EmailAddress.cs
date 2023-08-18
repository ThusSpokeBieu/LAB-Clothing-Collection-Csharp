using LABCC.Domain.Exceptions;
using LABCC.Domain.Utils;
using ValueOf;

namespace LABCC.Domain.Entities.Users.VO;

public sealed class EmailAddress : ValueOf<string, EmailAddress>
{
    protected override void Validate()
    {
        if (RegexConst.EmailRegex().IsMatch(Value)) return;
        var message = $"{Value} is not a valid email address";
        throw new ValidationException(message);
    }
}