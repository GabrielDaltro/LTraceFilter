namespace LTraceFilter.Business.Application.Abstractions
{
    public interface ISignalRepository
    {
        (float[]?, int?) GetSignal();

        void UpdateSignal(float[] newSignal, int sampleRate);
    }
}
