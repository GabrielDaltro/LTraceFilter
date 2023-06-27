using Microsoft.Extensions.DependencyInjection;

namespace LTraceFilter.Presentation.WinForms.Views
{
    internal class ViewFactory
    {
        private readonly IServiceProvider serviceProvider;

        public ViewFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public SignalFilteringView CreateSignalFilteringView()
        {
            return serviceProvider.GetRequiredService<SignalFilteringView>();
        }
    }
}