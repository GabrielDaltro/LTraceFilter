using LTraceFilter.Business.Domain.Abstractions;

namespace LTraceFilter.Business.Domain.Factory
{
    public class FilterFactory
    {
        public ILowPassFilter CreateLowPassFilter(double lowCutoffFrequency, int samplingRate) 
        {
            var accordLowFilter = new Accord.Audio.Filters.LowPassFilter(lowCutoffFrequency, samplingRate);
            ILowPassFilter lowPassFilter = new LowPassFilter(lowCutoffFrequency, samplingRate, accordLowFilter);
            return lowPassFilter;
        }

        public IHighPassFilter CreateHighPassFilter(double highCutoffFrequency, int samplingRate) 
        {
            var accordHighFilter = new Accord.Audio.Filters.HighPassFilter(highCutoffFrequency, samplingRate);
            IHighPassFilter highPassFilter = new HighPassFilter(highCutoffFrequency, samplingRate, accordHighFilter);
            return highPassFilter;

        }

        public BandPassFilter CreateBandPassFilter(double lowCutoffFrequency, double highCutoffFrequency, int samplingRate)
        {
            var lowPassFilter = CreateLowPassFilter(lowCutoffFrequency, samplingRate);
            var highPassFilter = CreateHighPassFilter(highCutoffFrequency, samplingRate);
            return new BandPassFilter(lowPassFilter, highPassFilter);
        }
    }
}