using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Service.Utilities
{
    public class Hasher
    {
        //SHA256

        public string GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);

            SHA256Managed sha256 = new SHA256Managed();

            byte[] hash = sha256.ComputeHash(bytes);

            return hash.ToString();
        }

        private string CreateSalt(int saltSize)
        {
            var rng = new RNGCryptoServiceProvider();

            var buff = new byte[saltSize];

            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }
    }
}