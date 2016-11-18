using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Data
{
    public class MyPasswordHasher : PasswordHasher
    {
        public override PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            return hashedPassword.Equals(HashPassword(providedPassword)) ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }

        public override string HashPassword(string password)
        {
            var Sha1 = new  SHA1CryptoServiceProvider() ;
            var textToHash = Encoding.Default.GetBytes(password);
            var res = Sha1.ComputeHash(textToHash);
            var resText = Convert.ToBase64String(res);
            resText.Replace('+', '_');
            resText.Replace('=', '_');
            resText.Replace('+', '_');
            return resText ;
        }
    }
}
