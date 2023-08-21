using LABCC.Domain.Exceptions;
using LABCC.Domain.Utils;
using ValueOf;

namespace LABCC.Domain.Entities.Users.VO;

public sealed class Document : ValueOf<string, Document>
{
    protected override void Validate()
    {
        if (RegexConst.CpfOrCnpjDocumentRegex().IsMatch(Value)) return;
        var message = $"{Value} is not a valid document pattern, must be a CPF or CNPJ.";
        throw new ValidationException(message);
    }
}