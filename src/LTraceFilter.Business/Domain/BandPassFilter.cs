using LTraceFilter.Business.Domain.Abstractions;

namespace LTraceFilter.Business.Domain
{
    public class BandPassFilter : BasePipeline<float>
    {
        private readonly ILowPassFilter lowPassFilter;
        private readonly IHighPassFilter highPassFilter;

        public int SamplingRate 
        { 
            get => lowPassFilter.SamplingRate;
            set
            {
                if (value > 0)
                {
                    lowPassFilter.SamplingRate = value;
                    highPassFilter.SamplingRate = value;
                }
                else
                    throw new DomainException("SamplingRate must be greater than 0");
            }
        }

        public double LowCutoffFrequency 
        {
            get => lowPassFilter.CutoffFrequency;
            set => lowPassFilter.CutoffFrequency = value;
        }

        public double HighCutoffFrequency 
        {
            get => highPassFilter.CutoffFrequency;
            set => highPassFilter.CutoffFrequency = value; 
        }

        public BandPassFilter(ILowPassFilter lowPassFilter, IHighPassFilter highPassFilter) 
            : base(new List<IFilter<float>>() { lowPassFilter, highPassFilter })
        {
            this.lowPassFilter = lowPassFilter;
            this.highPassFilter = highPassFilter;
            CheckConsistency();
        }

        private void CheckConsistency()
        {
            if (lowPassFilter.SamplingRate != highPassFilter.SamplingRate)
                throw new DomainException("Sampling rate of high pass filter and low pass filter must be equals");
        }
    }
}