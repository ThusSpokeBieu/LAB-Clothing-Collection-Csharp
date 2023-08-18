using LABCC.Domain.Enums;
using LABCC.Domain.Exceptions;
using ValueOf;

namespace LABCC.Domain.Entities.Users.VO;

public sealed class Gender : ValueOf<GenderEnum, Gender>
{
    public static GenderEnum GetGenderEnum(string gender)
    {
        if (Enum.TryParse(gender, true, out GenderEnum result)) return result;
        throw new ValidationException("Gender is not valid, must be: male, female or other.");
    }

    public static Gender From(string gender)
    {
        try
        {
            var gEnum = GetGenderEnum(gender);
            return From(gEnum);
        }
        catch (ValidationException e)
        {
            throw new ValidationException(e.Message);
        }
    }
}