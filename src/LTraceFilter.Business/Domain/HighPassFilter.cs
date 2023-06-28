/*anticorruption layer for 3rd party lib: Accord*/
using LTraceFilter.Business.Domain.Abstractions;

using AccordLib = Accord.Audio.Filters;

namespace LTraceFilter.Business.Domain
{
    internal class HighPassFilter : BaseFilter<AccordLib.HighPassFilter>, IHighPassFilter
    {
        public HighPassFilter(double cutoffFrequency, int samplingRate, AccordLib.HighPassFilter accordFilter) 
            : base(cutoffFrequency, samplingRate, accordFilter)
        {
        }

        protected override void SetAlpha(double cutoffFrequency, int sampleRate)
        {
            wrappedFilter.Alpha = AccordLib.HighPassFilter.GetAlpha(cutoffFrequency, sampleRate);
        }

        protected override void SetAlpha(float alpha)
        {
            wrappedFilter.Alpha = 1;
        }
    }
}