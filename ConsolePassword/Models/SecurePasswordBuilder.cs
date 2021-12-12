using System.Security;

namespace ConsolePassword.Models
{
    internal class SecuredPasswordBuilder : IPasswordBuilder
    {
        private readonly SecureString _password = new SecureString();

        public void AppendChar(char character)
        {
            _password.AppendChar(character);
        }

        public bool RemoveLast()
        {
            if (_password.Length <= 0) return false;
            
            _password.RemoveAt(_password.Length - 1);
            return true;

        }

        public object Build() => _password;
    }
}