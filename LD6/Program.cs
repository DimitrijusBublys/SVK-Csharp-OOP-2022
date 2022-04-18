namespace Encrypt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "";
            int passwordLength;
            while(String.IsNullOrEmpty(password))
            {
                Console.WriteLine("Your password: ");
                password = Console.ReadLine();
            }
            passwordLength = password.Length;
            EncryptPassword obj = new EncryptPassword(password, passwordLength);
        }
    }
}