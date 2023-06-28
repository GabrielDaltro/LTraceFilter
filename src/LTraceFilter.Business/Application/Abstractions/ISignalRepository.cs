namespace LTraceFilter.Business.Application.Abstractions
{
    public interface ISignalRepository
    {
        (float[], int) GetSignal();
    }
}
