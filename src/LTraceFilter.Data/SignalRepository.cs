using LTraceFilter.Business.Application.Abstractions;
using LTraceFilter.Data.DTOs;

namespace LTraceFilter.Data
{
    public class SignalRepository : BaseReposiory, ISignalRepository
    {
        public SignalRepository(string path) : base(path) { }

        public (float[]?, int?) GetSignal()
        {
            var dto = GetFromFile<SignalDto>();
            return (dto.Samples, dto.SampleRate);
        }

        public void UpdateSignal(float[] newSignal, int sampleRate)
        {
            SaveIntoFile(new SignalDto { SampleRate = sampleRate, Samples = newSignal });
        }
    }
}