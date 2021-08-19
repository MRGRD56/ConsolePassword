namespace ConsolePassword.Models.Factory
{
    internal class StringPasswordBuilderFactory : IPasswordBuilderFactory
    {
        public IPasswordBuilder Create() => new StringPasswordBuilder();
    }
}