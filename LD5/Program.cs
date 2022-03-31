using System;

namespace StrongPasswordGen
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int PasswordAmount;
            int PasswordLength;

            Console.WriteLine("\nHow many passwords should be generated?:");
            PasswordAmount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the password length (chars):");
            PasswordLength = int.Parse(Console.ReadLine());

            Password obj = new Password(PasswordAmount, PasswordLength);
            obj.dataToArray();


        }
    }

}