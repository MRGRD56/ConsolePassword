using System;
using System.Security;
using ConsolePassword.Models.Factory;

namespace ConsolePassword
{
    public static class PasswordReader
    {
        private static object ReadPasswordObject(
            IPasswordBuilderFactory passwordBuilderFactory, 
            bool displayPasswordCharacter = true, 
            Func<char> passwordCharacterGetter = null)
        {
            var password = passwordBuilderFactory.Create();
            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    if (displayPasswordCharacter)
                    {
                        Console.WriteLine();
                    }
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
                    if (displayPasswordCharacter && passwordCharacterGetter != null)
                    {
                        Console.Write(passwordCharacterGetter());
                    }
                }
            }
            
            return password.Build();
        }

        private static TResult ReadPassword<TResult, TPasswordBuilderFactory>(
            bool displayPasswordCharacter,
            char passwordCharacter = '*',
            Func<char> passwordCharacterGetter = null) where TPasswordBuilderFactory : IPasswordBuilderFactory, new()
        {
            if (passwordCharacterGetter == null)
            {
                passwordCharacterGetter = () => passwordCharacter;   
            }
            return (TResult)ReadPasswordObject(
                new TPasswordBuilderFactory(), 
                displayPasswordCharacter, 
                passwordCharacterGetter);
        }

        public static string ReadPassword(bool displayPasswordCharacter = true) =>
            ReadPassword<string, StringPasswordBuilderFactory>(displayPasswordCharacter);
        public static string ReadPassword(char passwordCharacter) =>
            ReadPassword<string, StringPasswordBuilderFactory>(true, passwordCharacter);
        public static string ReadPassword(Func<char> passwordCharacterGetter) =>
            ReadPassword<string, StringPasswordBuilderFactory>(true, passwordCharacterGetter: passwordCharacterGetter);
        
        public static SecureString ReadSecurePassword(bool displayPasswordCharacter = true) =>
            ReadPassword<SecureString, SecurePasswordBuilderFactory>(displayPasswordCharacter);
        public static SecureString ReadSecurePassword(char passwordCharacter) =>
            ReadPassword<SecureString, SecurePasswordBuilderFactory>(true, passwordCharacter);
        public static SecureString ReadSecurePassword(Func<char> passwordCharacterGetter) =>
            ReadPassword<SecureString, SecurePasswordBuilderFactory>(true, passwordCharacterGetter: passwordCharacterGetter);
    }
}