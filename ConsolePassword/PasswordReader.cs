using System;
using System.Security;
using ConsolePassword.Models.Factory;

namespace ConsolePassword
{
    public static class PasswordReader
    {
        private static object ReadPasswordObject(IPasswordBuilderFactory passwordBuilderFactory)
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
                    Console.Write("\b \b");
                }
                else if (key.KeyChar != '\u0000')
                {
                    password.AppendChar(key.KeyChar);
                    Console.Write("*");
                }
            }
            
            return password.Build();
        }

        public static string ReadPassword() => 
            (string)ReadPasswordObject(new StringPasswordBuilderFactory());
        
        public static SecureString ReadSecuredPassword() => 
            (SecureString)ReadPasswordObject(new SecuredPasswordBuilderFactory());
    }
}