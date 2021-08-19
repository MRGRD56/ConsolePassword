using System;
using ConsolePassword.Extensions;

namespace ConsolePassword.Test
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var password = PasswordReader.ReadSecuredPassword();
            Console.WriteLine(password.GetString());
        }
    }
}