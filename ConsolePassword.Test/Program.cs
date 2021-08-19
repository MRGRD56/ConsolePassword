using System;
using ConsolePassword.Extensions;

namespace ConsolePassword.Test
{
    internal static class Program
    {
        private static readonly Random Random = new();
        
        private static char GetPasswordCharacter()
        {
            const string characters = "@#$%&*+";
            return characters[Random.Next(0, characters.Length)];
        }
        
        private static void Main(string[] args)
        {
            var password = PasswordReader.ReadSecurePassword(GetPasswordCharacter);
            Console.WriteLine(password.GetString());
        }
    }
}