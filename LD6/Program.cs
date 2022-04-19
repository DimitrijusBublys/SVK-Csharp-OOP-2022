using System;
using System.Security.Cryptography;

namespace Encrypt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "";
            var key = "PeShVmYq3t6w9z$C&F)H@McQfTjWnZr4";
            while (String.IsNullOrEmpty(password))
            {
                Console.WriteLine("Enter your password:");
                password = Console.ReadLine();
            }
            var encrypted = EncryptPassword.Encrypted(key, password);

            Console.WriteLine(encrypted);

            var decrypted = EncryptPassword.Decrypted(key, encrypted);

            Console.WriteLine(decrypted);
        }
    }
}