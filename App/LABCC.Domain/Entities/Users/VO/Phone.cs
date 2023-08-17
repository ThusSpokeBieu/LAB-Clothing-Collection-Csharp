using LABCC.Domain.Exceptions;
using LABCC.Domain.Utils;
using ValueOf;

namespace LABCC.Domain.ValueObjects;

public sealed class Phone : ValueOf<string, Phone>
{
    protected override void Validate()
    {
        if (RegexConst.BrazilPhoneNumber().IsMatch(Value)) return;
        var message = $"{Value} is not a valid phone number pattern.";
        throw new ValidationException(message);
    }
}