using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Encrypt
{
    internal class EncryptPassword
    {
        public string originalPw;
        public int lengthPw;
        private static byte[] IV = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    
        public EncryptPassword(string password, int passwordLength){
            originalPw = password;
            lengthPw = passwordLength;
        }

        public string Encryption(string placeholder, string originalPw, byte[] IV)
        {
            byte[] Key = Encoding.UTF8.GetBytes(originalPw);
            AesManaged aes = new AesManaged();
            aes.Key = Key;
            aes.IV = IV;

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);

            byte[] InputBytes = Encoding.UTF8.GetBytes(placeholder);
            cryptoStream.Write(InputBytes,0, InputBytes.Length);
            cryptoStream.FlushFinalBlock();

            byte[] Encrypted = memoryStream.ToArray();

            Console.WriteLine(Encrypted);

            return Convert.ToBase64String(Encrypted);
            
        }
    }
}
