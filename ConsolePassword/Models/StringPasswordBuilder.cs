using System.Text;

namespace ConsolePassword.Models
{
    internal class StringPasswordBuilder : IPasswordBuilder
    {
        private readonly StringBuilder _password = new();
        
        public void AppendChar(char character)
        {
            _password.Append(character);
        }

        public void RemoveLast()
        {
            if (_password.Length > 0)
            {
                _password.Remove(_password.Length - 1, 1);
            }
        }

        public object Build() => _password.ToString();
    }
}