namespace RestGenerator.Infrastructure.Configurations.Implementation
{
    internal class Configurations : IConfigurations
    {
        // public string DatabaseConnectionString => "Server=STEB\\SQLEXPRESS; Database=RestGenerator; User id=RestGeneratorLogin; Password=Test!2345";
        public string DatabaseConnectionString => "Server=localhost\\SQLEXPRESS; Database=RestGenerator; User id=RestGeneratorLogin; Password=Test!2345";
    }
}
