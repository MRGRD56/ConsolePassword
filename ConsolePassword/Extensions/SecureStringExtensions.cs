using System;
using System.Runtime.InteropServices;
using System.Security;

namespace ConsolePassword.Extensions
{
    public static class SecureStringExtensions
    {
        public static string GetString(this SecureString secureString)
        {
            var valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
    }
}