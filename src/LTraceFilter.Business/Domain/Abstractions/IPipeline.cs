namespace LTraceFilter.Business.Domain.Abstractions
{
    internal interface IPipeline<T>
    {
        T[] Apply(T[] inputSignal);
    }
}