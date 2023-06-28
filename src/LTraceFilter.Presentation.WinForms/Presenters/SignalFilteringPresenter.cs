using LTraceFilter.Business.Application;
using LTraceFilter.Business.Application.Abstractions;

namespace LTraceFilter.Presentation.WinForms.Presenters
{
    internal class SignalFilteringPresenter
    {
        private readonly ISignalRepository signalRepository;
        private readonly SignalFilteringAppService appService;
        private readonly IFilterSettingsRepository filterSettingsRepository;

        public SignalFilteringPresenter(ISignalRepository signalRepository, 
                                        SignalFilteringAppService appService,
                                        IFilterSettingsRepository filterSettingsRepository)
        {
            this.appService = appService;
            this.signalRepository = signalRepository;
            this.filterSettingsRepository = filterSettingsRepository;
        }

        public (float[] signal, int sampleRateHz) GetSignal()
        {
            return signalRepository.GetSignal();
        }

        public (float? initialLowPassCutoff, float? initialHighPassCutoff) GetInitialFilterSettings()
        {
            return (filterSettingsRepository.GetLowPassCutoffFrequency(), filterSettingsRepository.GetHighPassCutoffFrequency());
        }

        public float[] FilterSignal(float? lowPassCutoffFrequency, float? highPassCutoffFrequency)
        {
            appService.LoadSignal();
            return appService.FilterSignal(lowPassCutoffFrequency, highPassCutoffFrequency);
        }
    }
}