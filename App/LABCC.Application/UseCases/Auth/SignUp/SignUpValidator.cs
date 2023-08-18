using FluentValidation;
using LABCC.Domain.Enums;
using LABCC.Domain.Utils;

namespace LABCC.Application.UseCases.Auth.SignUp;

public sealed class SignUpValidator : Validator<SignUpRequest>
{
    public SignUpValidator()
    {
        RuleFor(x => x.Email)
            .Matches(RegexConst.EmailRegex())
            .WithMessage("Must be a valid email!");
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MinimumLength(2)
            .WithMessage("Name it's too short!")
            .Matches(RegexConst.PersonalName())
            .WithMessage("Must be a valid name!");
        
        RuleFor(x => x.Document)
            .NotEmpty()
            .WithMessage("Document is required")
            .Matches(RegexConst.CpfOrCnpjDocumentRegex())
            .WithMessage("Document must be a valid CPF or CNPJ document!");
        

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(8)
            .WithMessage("Password it's too short! Must have at least 8 characters");

        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("Phone is required")
            .Matches(RegexConst.BrazilPhoneNumber())
            .WithMessage("Must be a valid brazil phone number");
        
        RuleFor(x => x.Gender)
            .NotEmpty()
            .WithMessage("Gender is required!")
            .Must(g => Enum.TryParse(g, true, out GenderEnum _))
            .WithMessage("Must be a valid gender: Male, Female or Other");
        
        RuleFor(x => x.DateOfBirth)
            .NotEmpty()
            .WithMessage("Date of birth is required!")
            .Must(d => d < DateOnly.FromDateTime(DateTime.Now.AddYears(-18)))
            .WithMessage("Must be have over than 18 years to register in this system");
    }
}