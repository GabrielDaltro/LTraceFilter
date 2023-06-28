using LTraceFilter.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace LTraceFilter.Presentation.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var hostBuilder = new HostBuilder();

            hostBuilder.ConfigureAppSettings();

            hostBuilder.ConfigureServices((hostContext, services) => {
                services.ConfigureDI(hostContext.Configuration);
            });

            var host = hostBuilder.Build();

            ApplicationConfiguration.Initialize();
            Application.Run(host.Services.GetRequiredService<MainForm>());
        }
    }
}