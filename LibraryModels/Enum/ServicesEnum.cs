
namespace ServicesEnum
{
    public enum SchemaDB
    {
        System = 1,
        Profile = 2
    }

    public enum ConfigurationApp
    {
        DefaultUserId = 1
    }

    public enum Procedures
    {
        InserToken = 1,
        GetTokenByDate = 2,
        GetUserByRegisterNumberAndPassword = 3,
        InsertUser = 4,
        GetUserById = 5,
        GetUserByRegisterNumber = 6
    }

    public enum TokenType
    {
        Gov = 1
    }
}
