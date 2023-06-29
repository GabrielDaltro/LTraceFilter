using LTraceFilter.Business.Domain;
using LTraceFilter.Business.Domain.Factory;
using LTraceFilter.Business.Domain.Abstractions;
using LTraceFilter.Business.Application.Abstractions;

namespace LTraceFilter.Business.Application
{
    public class SignalFilteringAppService
    {
        private float[]? signal;
        private int? samplingRate;

        private readonly FilterFactory filterFactory;
        private readonly ISignalRepository signalRepository;
        private readonly IFilterSettingsRepository filterSettingsRepository;
        private readonly ISignalReader signalReader;

        private BandPassFilter? bandPassFilter;
        private ILowPassFilter? lowPassFilter;
        private IHighPassFilter? highPassFilter;

        public SignalFilteringAppService(ISignalRepository signalRepository, 
                                         FilterFactory filterFactory,
                                         IFilterSettingsRepository filterSettingsRepository,
                                         ISignalReader signalReader)
        {
            this.signalRepository = signalRepository;
            this.filterFactory = filterFactory;
            this.filterSettingsRepository = filterSettingsRepository;
            this.signalReader = signalReader;
        }

        // TO DO: verificar se essa função precisa ser refatorada
        public void LoadSignal()
        {
            (signal, samplingRate) = signalRepository.GetSignal();
        }

        public void PersisteNewSignal(float[] newSignal, int sampleRate)
        {
            signalRepository.UpdateSignal(newSignal, sampleRate);
        }

        public float[] ImportNewSignal(string path)
        {
            return signalReader.ReadSignalFromFile(path);
        }

        public (float[]? signal, int? sampleRate) FilterSignal(float? lowPassCutoffFrequency, float? highPassCutoffFrequency)
        {
            filterSettingsRepository.SetBothCutoffFrequency(lowPassCutoffFrequency, highPassCutoffFrequency);

            if (signal == null || samplingRate == null)
                return (null, null);

            float[] signalResult;

            if (lowPassCutoffFrequency == null && highPassCutoffFrequency == null)
                signalResult = signal;
            else if (lowPassCutoffFrequency != null && highPassCutoffFrequency == null)
                signalResult = FilterWithLowPass(lowPassCutoffFrequency.Value, samplingRate.Value);
            else if (lowPassCutoffFrequency == null && highPassCutoffFrequency != null)
                signalResult = FilterWithHighPass(highPassCutoffFrequency.Value, samplingRate.Value);
            else
                signalResult = FilterWithBandPass(lowPassCutoffFrequency!.Value, highPassCutoffFrequency!.Value, samplingRate.Value);

            return (signalResult, samplingRate);
        }

        private float[] FilterWithLowPass(float lowPassCutoffFrequency, int samplingRate)
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

        private float[] FilterWithHighPass(float highPassCutoffFrequency, int samplingRate)
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

        private float[] FilterWithBandPass(float lowPassCutoffFrequency, float highPassCutoffFrequency, int samplingRate)
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