using System.Text.RegularExpressions;

namespace LABCC.Domain.Utils;

public static partial class RegexConst
{
    [GeneratedRegex(RegexPatterns.Email, RegexOptions.IgnoreCase)]
    public static partial Regex EmailRegex();

    [GeneratedRegex(RegexPatterns.PersonalName, RegexOptions.IgnoreCase)]
    public static partial Regex PersonalName();
    
    [GeneratedRegex(RegexPatterns.CnpjOrCpfDocument)]
    public static partial Regex CpfOrCnpjDocumentRegex();
    
    [GeneratedRegex(RegexPatterns.NotNumericalDigit)]
    public static partial Regex NotNumericalDigit();

    [GeneratedRegex(RegexPatterns.CpfDocument)]
    public static partial Regex CpfDocumentRegex();

    [GeneratedRegex(RegexPatterns.CnpjDocument)]
    public static partial Regex CnpjDocumentRegex();
    
    [GeneratedRegex(RegexPatterns.BrazilPhoneNumber)]
    public static partial Regex BrazilPhoneNumber();

}