using Microsoft.Extensions.Configuration.Json;
using ServicesEnum;

namespace ProjectApi.DataBase
{
    public class ConnectStringManager
    {
        public string GetConnectString(SchemaDB key)
        {
            string? schema = Enum.GetName(typeof(SchemaDB), key);

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, reloadOnChange: true);
            return builder.Build().GetSection("ConnectionStrings").GetSection(schema).Value;
        }
    }
}
