using LTraceFilter.Business.Application.Abstractions;
using LTraceFilter.Data.DTOs;

namespace LTraceFilter.Data
{
    public class FilterSettingsRepository : BaseReposiory, IFilterSettingsRepository
    {

        public FilterSettingsRepository(string path) : base(path) { }

        public float? GetHighPassCutoffFrequency()
        {
            return GetFromFile<FilterSettingsDto>().HighCutoffFrequency;
        }

        public float? GetLowPassCutoffFrequency()
        {
            return GetFromFile<FilterSettingsDto>().LowCutoffFrequency;
        }

        public void SetBothCutoffFrequency(float? lowPassFrequency, float? highPassFrequency)
        {
            var dto = new FilterSettingsDto()
            {
                LowCutoffFrequency = lowPassFrequency,
                HighCutoffFrequency = highPassFrequency
            };
            SaveIntoFile(dto);
        }

        public void SetHighPassCutoffFrequency(float? frequency)
        {
            var dto = new FilterSettingsDto()
            {
                LowCutoffFrequency = GetLowPassCutoffFrequency(),
                HighCutoffFrequency = frequency
            };
            SaveIntoFile(dto);
        }

        public void SetLowPassCutoffFrequency(float? frequency)
        {
            throw new NotImplementedException();
        }
    }
}