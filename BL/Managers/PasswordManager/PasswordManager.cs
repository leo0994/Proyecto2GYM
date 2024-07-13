
using DTOs;
using DAO.Crud;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace BL.Managers
{
    public class PasswordManager
    {
        private readonly PasswordCrudFactory _crudFactory;

        public PasswordManager()
        {
            _crudFactory = new PasswordCrudFactory();
        }

        public PasswordDTO Create(PasswordDTO password)
        {
            return _crudFactory.Create(password);
        }

        public PasswordDTO Update(PasswordDTO password)
        {
            return _crudFactory.Update(password);
        }

        public PasswordDTO Delete(PasswordDTO password)
        {
            return _crudFactory.Delete(password);
        }

        public List<PasswordDTO> RetrieveAll()
        {
            return _crudFactory.RetrieveAll();
        }

        public PasswordDTO RetrieveById(int id)
        {
            return _crudFactory.RetrieveById(id);
        }
    }

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
