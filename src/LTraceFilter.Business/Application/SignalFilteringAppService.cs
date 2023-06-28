using LTraceFilter.Business.Domain;
using LTraceFilter.Business.Domain.Factory;
using LTraceFilter.Business.Domain.Abstractions;
using LTraceFilter.Business.Application.Abstractions;

namespace LTraceFilter.Business.Application
{
    public class SignalFilteringAppService
    {
        private float[]? signal;
        private int samplingRate;

        private readonly FilterFactory filterFactory;
        private readonly ISignalRepository signalRepository;
        private readonly IFilterSettingsRepository filterSettingsRepository;
        
        private BandPassFilter? bandPassFilter;
        private ILowPassFilter? lowPassFilter;
        private IHighPassFilter? highPassFilter;

        public SignalFilteringAppService(ISignalRepository signalRepository, 
                                         FilterFactory filterFactory,
                                         IFilterSettingsRepository filterSettingsRepository)
        {
            this.signalRepository = signalRepository;
            this.filterFactory = filterFactory;
            this.filterSettingsRepository = filterSettingsRepository;
        }

        // essa função é realmente necessária?
        public void LoadSignal()
        {
            (signal, samplingRate) = signalRepository.GetSignal();
        }

        public float[] FilterSignal(float? lowPassCutoffFrequency, float? highPassCutoffFrequency)
        {
            if (signal == null)
                throw new Exception("It is need to call LoadSignal method before calling FilterSignal method.");

            filterSettingsRepository.SetBothCutoffFrequency(lowPassCutoffFrequency, highPassCutoffFrequency);

            if (lowPassCutoffFrequency == null && highPassCutoffFrequency == null)
                return signal;
            else if (lowPassCutoffFrequency != null && highPassCutoffFrequency == null)
                return FilterWithLowPass(lowPassCutoffFrequency.Value);
            else if (lowPassCutoffFrequency == null && highPassCutoffFrequency != null)
                return FilterWithHighPass(highPassCutoffFrequency.Value);
            else
                return FilterWithBandPass(lowPassCutoffFrequency!.Value, highPassCutoffFrequency!.Value);
        }

        private float[] FilterWithLowPass(float lowPassCutoffFrequency)
        {
            if (lowPassFilter == null)
                lowPassFilter = filterFactory.CreateLowPassFilter(lowPassCutoffFrequency, samplingRate);
            else
            {
                lowPassFilter.CutoffFrequency = lowPassCutoffFrequency;
                lowPassFilter.SamplingRate = samplingRate;
            }
            return lowPassFilter.Apply(signal!);
        }

        private float[] FilterWithHighPass(float highPassCutoffFrequency)
        {
            if (highPassFilter == null)
                highPassFilter = filterFactory.CreateHighPassFilter(highPassCutoffFrequency, samplingRate);
            else
            {
                highPassFilter.CutoffFrequency = highPassCutoffFrequency;
                highPassFilter.SamplingRate = samplingRate;
            }
            return highPassFilter.Apply(signal!);
        }

        private float[] FilterWithBandPass(float lowPassCutoffFrequency, float highPassCutoffFrequency)
        {
            if (bandPassFilter == null)
                bandPassFilter = filterFactory.CreateBandPassFilter(lowPassCutoffFrequency, highPassCutoffFrequency, samplingRate);
            else
            {
                bandPassFilter.LowCutoffFrequency = lowPassCutoffFrequency;
                bandPassFilter.HighCutoffFrequency = highPassCutoffFrequency;
            }

            return bandPassFilter.Apply(signal!);
        }
    }
}