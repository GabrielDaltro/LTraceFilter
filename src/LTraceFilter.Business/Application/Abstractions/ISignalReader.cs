namespace LTraceFilter.Business.Application.Abstractions
{
    public interface ISignalReader
    {
        float[] ReadSignalFromFile(string path);
    }
}