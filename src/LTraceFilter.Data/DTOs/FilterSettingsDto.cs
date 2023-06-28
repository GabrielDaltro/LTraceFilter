using Newtonsoft.Json;

namespace LTraceFilter.Data.DTOs
{
    internal class FilterSettingsDto
    {
        [JsonProperty(PropertyName = "lowCutoffFrequency")]
         public float? LowCutoffFrequency { get; set; }

        [JsonProperty(PropertyName = "highCutoffFrequency")]
        public float? HighCutoffFrequency { get; set;  }
    }
}