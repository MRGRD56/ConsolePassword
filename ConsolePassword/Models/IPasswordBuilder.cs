namespace ConsolePassword.Models
{
    internal interface IPasswordBuilder
    {
        void AppendChar(char character);
        void RemoveLast();
        object Build();
    }
}