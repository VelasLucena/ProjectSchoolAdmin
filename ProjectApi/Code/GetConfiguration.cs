using ServicesEnum;

namespace ProjectApi.Code
{
    public class AppSettingsJson
    {
        public static string GetConfigurationApp(ConfigurationApp key)
        {
            string? config = Enum.GetName(typeof(ConfigurationApp), key);

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true, reloadOnChange: true);
            return builder.Build().GetSection("Settings").GetSection(config).Value;
        }
    }
}
