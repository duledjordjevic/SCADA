using System;
using System.Security.Cryptography;
using System.Text;

namespace CommonLibrary
{
    public class AuthProvider
    {
        public static string GenerateSalt()
        {
            var crypto = new RNGCryptoServiceProvider();
            byte[] salt = new byte[32];
            crypto.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public static string Encrypt(string password)
        {
            string salt = GenerateSalt();
            byte[] saltedPassword = Encoding.UTF8.GetBytes(salt + password);
            using (var sha = new SHA256Managed())
            {
                byte[] hash = sha.ComputeHash(saltedPassword);
                return $"{Convert.ToBase64String(hash)}:{salt}";
            }
        }

        public static bool Validate(string password, string encryptedPassword)
        {
            string[] arrValues = encryptedPassword.Split(':');
            string passwordHash = arrValues[0];
            string salt = arrValues[1];
            byte[] saltedPassword = Encoding.UTF8.GetBytes(salt + password);
            using (var sha = new SHA256Managed())
            {
                byte[] hash = sha.ComputeHash(saltedPassword);
                string enteredValueToValidate = Convert.ToBase64String(hash);
                return passwordHash.Equals(enteredValueToValidate);
            }
        }

        public static string GenerateToken(string username)
        {
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            byte[] randVal = new byte[32];
            crypto.GetBytes(randVal);
            string randStr = Convert.ToBase64String(randVal);
            return username + randStr;
        }

    }
}
