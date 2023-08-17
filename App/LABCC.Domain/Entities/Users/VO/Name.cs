using LABCC.Domain.Exceptions;
using LABCC.Domain.Utils;
using ValueOf;

namespace LABCC.Domain.ValueObjects;

public sealed class Name : ValueOf<string, Name>
{
    protected override void Validate()
    {
        if (RegexConst.PersonalName().IsMatch(Value)) return;
        var message = $"{Value} is not a valid personal name pattern.";
        throw new ValidationException(message);
    }
}