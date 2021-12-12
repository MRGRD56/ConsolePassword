namespace ConsolePassword.Models
{
    internal interface IPasswordBuilder
    {
        void AppendChar(char character);
        bool RemoveLast();
        object Build();
    }
}