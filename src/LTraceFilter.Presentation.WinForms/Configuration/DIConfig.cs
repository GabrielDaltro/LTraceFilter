using LTraceFilter.Data;
using LTraceFilter.Business.Application;
using LTraceFilter.Business.Application.Abstractions;
using LTraceFilter.Business.Domain.Factory;
using LTraceFilter.Presentation.WinForms;
using LTraceFilter.Presentation.WinForms.Presenters;
using LTraceFilter.Presentation.WinForms.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace LTraceFilter.Configuration
{
    internal static class DIConfig
    {
        public static IServiceCollection ConfigureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IFilterSettingsRepository>(services => {
                var path = configuration.GetSection("PathConfigurations")["filterSettingsPath"];
                if (path == null)
                    throw new Exception("Error to read path configurations from appsettings.json");
                return new FilterSettingsRepository(path);
            });

            services.AddTransient<ISignalReader, SignalReader>();

            services.AddTransient<ISignalRepository>(services => {
                var path = configuration.GetSection("PathConfigurations")["SignalPersistencePath"];
                if (path == null)
                    throw new Exception("Error to read signal persistence path from appsettings.json");
                return new SignalRepository(path);
            });
            services.AddTransient<FilterFactory>();
            services.AddTransient<ViewFactory>();
            services.AddTransient<SignalFilteringAppService>();
            
            services.AddSingleton<SignalFilteringPresenter>();
            services.AddSingleton<MainPresenter>();
            services.AddSingleton<SignalFilteringView>();
            services.AddSingleton<MainForm>();
            return services;
        }
    }
}