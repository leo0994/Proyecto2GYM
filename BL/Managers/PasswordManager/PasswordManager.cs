using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BL.PasswordManager
{
    public class PasswordService
    {
          
        private static readonly byte[] FixedSalt = Encoding.UTF8.GetBytes("my_secret_key_gym"); // store in env variables

        private static byte[] HashPasswordWithFixedSalt(string password)
        {
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, FixedSalt, 10000))
            {
                return rfc2898DeriveBytes.GetBytes(256 / 8);
            }
        }

        public static string HashPassword(string password)
        {
            var hash = HashPasswordWithFixedSalt(password);
            var hashBytes = new byte[FixedSalt.Length + hash.Length];

            Array.Copy(FixedSalt, 0, hashBytes, 0, FixedSalt.Length);
            Array.Copy(hash, 0, hashBytes, FixedSalt.Length, hash.Length);

            return Convert.ToBase64String(hashBytes);
        }
    }

}