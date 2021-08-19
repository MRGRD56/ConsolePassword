using System;
using System.Security;
using ConsolePassword.Models.Factory;

namespace ConsolePassword
{
    public static class PasswordReader
    {
        private static object ReadPasswordObject(IPasswordBuilderFactory passwordBuilderFactory, bool displayPasswordCharacter = true)
        {
            var password = passwordBuilderFactory.Create();
            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (key.Key == ConsoleKey.Backspace)
                {
                    password.RemoveLast();
                    if (displayPasswordCharacter)
                    {
                        Console.Write("\b \b");
                    }
                }
                else if (key.KeyChar != '\u0000')
                {
                    password.AppendChar(key.KeyChar);
                    if (displayPasswordCharacter)
                    {
                        Console.Write("*");
                    }
                }
            }
            
            return password.Build();
        }

        public static string ReadPassword(bool displayPasswordCharacter = true) => 
            (string)ReadPasswordObject(new StringPasswordBuilderFactory(), displayPasswordCharacter);
        
        public static SecureString ReadSecuredPassword(bool displayPasswordCharacter = true) => 
            (SecureString)ReadPasswordObject(new SecuredPasswordBuilderFactory(), displayPasswordCharacter);
    }
}