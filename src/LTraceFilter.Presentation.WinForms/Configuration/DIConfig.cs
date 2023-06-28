using LTraceFilter.Data;
using LTraceFilter.Business.Application;
using LTraceFilter.Business.Application.Abstractions;
using LTraceFilter.Business.Domain.Factory;
using LTraceFilter.Presentation.WinForms;
using LTraceFilter.Presentation.WinForms.Presenters;
using LTraceFilter.Presentation.WinForms.Views;
using Microsoft.Extensions.DependencyInjection;

namespace LTraceFilter.Configuration
{
    internal static class DIConfig
    {
        public static IServiceCollection ConfigureDI(this IServiceCollection services)
        {
            services.AddTransient<ISignalRepository, SignalRepository>();
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