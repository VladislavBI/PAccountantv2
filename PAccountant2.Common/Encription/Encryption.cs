using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PAccountant2.Common.Encription
{
    public static class Encryption
    {
        public static byte[] Encrypt(string stringToEncrypt)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(stringToEncrypt));

            return md5.Hash;
        }

        public static bool IsEqual(byte[] firstValue, byte[] secondValue)
            => firstValue != null && secondValue != null && !firstValue.SequenceEqual(secondValue);
    }
}
