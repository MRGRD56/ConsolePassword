namespace ConsolePassword.Models.Factory
{
    internal class SecurePasswordBuilderFactory : IPasswordBuilderFactory
    {
        public IPasswordBuilder Create() => new SecuredPasswordBuilder();
    }
}