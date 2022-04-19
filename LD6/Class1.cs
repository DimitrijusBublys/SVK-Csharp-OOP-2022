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
        public static string Encrypted(string key, string password)
        {
            byte[] IV = new byte[16];
            AesManaged aes = new AesManaged();

            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = IV;

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);

            byte[] InputBytes = Encoding.UTF8.GetBytes(password);
            cryptoStream.Write(InputBytes, 0, InputBytes.Length);
            cryptoStream.FlushFinalBlock();

            byte[] Encrypted = memoryStream.ToArray();


            return Convert.ToBase64String(Encrypted);

        }

        public static string Decrypted(string key, string encrypted)
        {
            byte[] IV = new byte[16];
            byte[] buffer = Convert.FromBase64String(encrypted);

            AesManaged aes = new AesManaged();

            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = IV;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            MemoryStream memoryStream = new MemoryStream(buffer);
            CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read);
            StreamReader streamReader = new StreamReader((Stream)cryptoStream);

            return streamReader.ReadToEnd();
        }
    }
}