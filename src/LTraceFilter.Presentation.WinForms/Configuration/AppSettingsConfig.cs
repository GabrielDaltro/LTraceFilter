using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace LTraceFilter.Configuration
{
    internal static class AppSettingsConfig
    {
        public static IHostBuilder ConfigureAppSettings(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureAppConfiguration(configurationBuilder => {
                configurationBuilder
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("./Configuration/appsettings.json", optional: false, reloadOnChange: true)
                    .Build();
            });
            return hostBuilder;
        }
    }
}