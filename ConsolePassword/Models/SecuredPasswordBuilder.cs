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

        public void RemoveLast()
        {
            if (_password.Length > 0)
            {
                _password.RemoveAt(_password.Length - 1);
            }
        }

        public object Build() => _password;
    }
}