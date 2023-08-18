using Isopoh.Cryptography.Argon2;
using ValueOf;
using BCrypt.Net;

namespace LABCC.Domain.Entities.Users.VO;

public sealed class Password : ValueOf<string, Password>
{
    public static Password Hash(string item)
    {
        var hash = BCrypt.Net.BCrypt.HashPassword(item); //Argon2.Hash(item);
        return From(hash);
    }

    public static bool Verify(Password pass, string maybePass)
    {
        var hash = pass.Value;
        return BCrypt.Net.BCrypt.Verify(maybePass, hash);  //Argon2.Verify(hash, maybePass);
    }
    
   
}