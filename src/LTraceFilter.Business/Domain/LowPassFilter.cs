/*anticorruption layer for 3rd party lib: Accord*/
using LTraceFilter.Business.Domain.Abstractions;

using AccordLib = Accord.Audio.Filters;

namespace LTraceFilter.Business.Domain
{
    internal class LowPassFilter : BaseFilter<AccordLib.LowPassFilter>, ILowPassFilter
    {
        public LowPassFilter(double cutoffFrequency, int samplingRate, AccordLib.LowPassFilter accordFilter) 
            : base(cutoffFrequency, samplingRate, accordFilter)
        {
        }

        protected override void SetAlpha(double cutoffFrequency, int sampleRate)
        {
            wrappedFilter.Alpha = AccordLib.LowPassFilter.GetAlpha(cutoffFrequency, sampleRate);
        }

        protected override void SetAlpha(float alpha)
        {
            wrappedFilter.Alpha = 1;
        }
    }
}