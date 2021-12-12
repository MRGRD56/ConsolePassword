using System.Text;

namespace ConsolePassword.Models
{
    internal class StringPasswordBuilder : IPasswordBuilder
    {
        private readonly StringBuilder _password = new StringBuilder();
        
        public void AppendChar(char character)
        {
            _password.Append(character);
        }

        public bool RemoveLast()
        {
            if (_password.Length <= 0) return false;
            
            _password.Remove(_password.Length - 1, 1);
            return true;

        }

        public object Build() => _password.ToString();
    }
}