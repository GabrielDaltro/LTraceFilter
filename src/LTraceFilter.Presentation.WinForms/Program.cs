using LTraceFilter.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            hostBuilder.ConfigureServices(services => {
                services.ConfigureDI();
            });

            var host = hostBuilder.Build();

            ApplicationConfiguration.Initialize();
            Application.Run(host.Services.GetRequiredService<MainForm>());
        }
    }
}