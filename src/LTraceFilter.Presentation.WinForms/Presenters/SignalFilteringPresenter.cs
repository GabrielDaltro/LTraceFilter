using LTraceFilter.Business.Application;
using LTraceFilter.Business.Application.Abstractions;

namespace LTraceFilter.Presentation.WinForms.Presenters
{
    internal class SignalFilteringPresenter
    {
        private readonly ISignalRepository signalRepository;
        private readonly SignalFilteringAppService appService;

        public SignalFilteringPresenter(ISignalRepository signalRepository, SignalFilteringAppService appService)
        {
            this.appService = appService;
            this.signalRepository = signalRepository;
        }

        public (float[] signal, int sampleRateHz) GetSignal()
        {
            return signalRepository.GetSignal();
        }

        public float[] FilterSignal(float? lowPassCutoffFrequency, float? highPassCutoffFrequency)
        {
            appService.LoadSignal();
            return appService.FilterSignal(lowPassCutoffFrequency, highPassCutoffFrequency);
        }
    }
}