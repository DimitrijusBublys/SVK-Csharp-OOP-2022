using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace StrongPasswordGen
{
    internal class Password
    {

        static RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();

        int PasswordAmount = 0;
        int PasswordLength = 0;

        string CapitalLetters = "QWERTYUIOPASDFGHJKLZXCVBNM";
        string SmallLetters = "qwertyuiopasdfghjklzxcvbnm";
        string Digits = "0123456789";
        string SpecialCharacters = "!@#$%^&*()-_=+<,>.";

        public Password(int times, int length)
        {
            PasswordAmount = times;
            PasswordLength = length;
        }
        public void dataToArray()
        {
            string[] AllPasswords = new string[PasswordAmount];
            string AllChar = CapitalLetters + SmallLetters + Digits + SpecialCharacters;

            for (int i = 0; i < PasswordAmount; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int n = 0; n < PasswordLength; n++)
                {
                    sb = sb.Append(generateChar(AllChar));
                }

                AllPasswords[i] = sb.ToString();
                output(AllPasswords[i], i);
            }

        }

        private static char generateChar(string availableChars)
        {
            var byteArray = new byte[1];
            char c;
            do
            {
                provider.GetBytes(byteArray);
                c = (char)byteArray[0];

            } while (!availableChars.Any(x => x == c));

            return c;
        }

        public void output(string password, int i)
        {
            i += 1;
            Console.WriteLine("Generated password number " + i + " : " + password);
        }

    }
}
