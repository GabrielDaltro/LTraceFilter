namespace LTraceFilter.Business.Application.Abstractions
{
    public interface IFilterSettingsRepository
    {
        float? GetLowPassCutoffFrequency();
       
        void SetLowPassCutoffFrequency(float? frequency);

        float? GetHighPassCutoffFrequency();
        
        void SetHighPassCutoffFrequency(float? frequency);

        void SetBothCutoffFrequency(float? lowPassFrequency, float? highPassFrequency);
    }
}