using LTraceFilter.Presentation.WinForms;
using Microsoft.Extensions.DependencyInjection;

namespace LTraceFilter.Configuration
{
    internal static class DIConfig
    {
        public static IServiceCollection ConfigureDI(this IServiceCollection services)
        {
            services.AddSingleton<MainForm>();
            return services;
        }
    }
}