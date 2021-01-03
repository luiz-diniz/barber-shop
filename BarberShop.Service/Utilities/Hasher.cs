using System;
using System.Security.Cryptography;
using System.Text;

namespace BarberShop.Service.Utilities
{
    public class Hasher : IHasher
    {
        //SHA256
        public string GenerateHash(string input, string salt)
        { 
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);

            SHA256Managed sha256 = new SHA256Managed();

            byte[] hash = sha256.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }

        public string CreateSalt(int saltSize)
        {
            var rng = new RNGCryptoServiceProvider();

            var buff = new byte[saltSize];

            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }
    }
}