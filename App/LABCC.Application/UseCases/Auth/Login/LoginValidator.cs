using FluentValidation;
using LABCC.Domain.Utils;

namespace LABCC.Application.UseCases.Auth.Login;

public sealed class LoginValidator : Validator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.Credential)
            .Must(ValidCredential)
            .WithMessage("Credential must be a valid Email, Document (CPF or CNPJ) or Phone.");

        RuleFor(x => x.Password)
            .MinimumLength(8)
            .WithMessage("Password must have at least 8 characters length");
    }

    private static bool ValidCredential(string credential) =>
        RegexConst.EmailRegex().Match(credential).Success ||
        RegexConst.CpfOrCnpjDocumentRegex().Match(credential).Success ||
        RegexConst.BrazilPhoneNumber().Match(credential).Success ;

}