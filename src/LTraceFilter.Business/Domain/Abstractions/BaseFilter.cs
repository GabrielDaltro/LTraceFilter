/*anticorruption layer for 3rd party lib: Accord*/
using Accord.Audio;

using AccordLib = Accord.Audio.Filters;

namespace LTraceFilter.Business.Domain.Abstractions
{
    public abstract class BaseFilter<Tfilter> where Tfilter : AccordLib.BaseFilter
    {
        private double cutoffFrequency;
        private int samplingRate;
        protected readonly Tfilter wrappedFilter;

        public double CutoffFrequency
        {
            get => cutoffFrequency;
            set
            {
                cutoffFrequency = value;
                SetAlpha(cutoffFrequency, samplingRate);
            }
        }

        public int SamplingRate
        {
            get => samplingRate;
            set
            {
                if (value > 0)
                {
                    samplingRate = value;
                    SetAlpha(cutoffFrequency, samplingRate);
                }
                else
                {
                    throw new DomainException("Sampling rate must be greater than 0");
                }
            }
        }

        public BaseFilter(double cutoffFrequency, int samplingRate, Tfilter wrappedFilter)
        {
            this.wrappedFilter = wrappedFilter;
            this.cutoffFrequency = cutoffFrequency;
            this.samplingRate = samplingRate;
        }

        public float[] Apply(float[] inputSignal)
        {
            Signal result = wrappedFilter.Apply(MapToSignal(inputSignal));
            var arrayResult = result.ToFloat();
            result.Dispose();
            return arrayResult;
        }

        protected abstract void SetAlpha(double cutoffFrequency, int sampleRate);

        protected abstract void SetAlpha(float alpha);

        private Signal MapToSignal(float[] inputSignal)
        {
            return Signal.FromArray(inputSignal, samplingRate);
        }

        private float[] MapToFloatArray(Signal signal)
        {
            float[] result = new float[signal.Length / 4];
            using (var stream = new MemoryStream(signal.RawData))
            {
                int index = 0;
                do
                {
                    result[index] = stream.ReadFloat();
                }
                while (stream.Position < stream.Length);
            }
            return result;
        }
    }
}