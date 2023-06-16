using System.Security.Cryptography;
using System.Text;

namespace Application.Services
{
    public class PasswordService
    {
        public static string ToPassword(string password) => ToSHA256(password);
        public static string ToSHA1(string value) => GenericHash(SHA1.Create(), value);
        public static string ToSHA256(string value) => GenericHash(SHA256.Create(), value);
        public static string ToSHA512(string value) => GenericHash(SHA512.Create(), value);
        public static string ToMD5(string value) => GenericHash(MD5.Create(), value);
        private static string GenericHash(HashAlgorithm hash, string value)
        {
            var byteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(value));
            return Convert.ToHexString(byteArray);
        }
    }
}