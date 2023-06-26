namespace LTraceFilter.Business.Domain.Abstractions
{
    internal interface IFilter<T>
    {
        double CutoffFrequency { get; set; }

        int SamplingRate { get; set; }

        T[] Apply(T[] inputSignal);
    }
}