namespace ConsolePassword.Models.Factory
{
    internal class SecuredPasswordBuilderFactory : IPasswordBuilderFactory
    {
        public IPasswordBuilder Create() => new SecuredPasswordBuilder();
    }
}