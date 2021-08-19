﻿using System;
using ConsolePassword.Extensions;

namespace ConsolePassword.Test
{
    internal static class Program
    {
        private static readonly Random Random = new();

        private static void Main(string[] args)
        {
            Console.Write("Password: ");
            var password = PasswordReader.ReadSecurePassword();
            Console.WriteLine(password.GetString());
        }
    }
}