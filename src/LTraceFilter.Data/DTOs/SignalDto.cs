using Newtonsoft.Json;

namespace LTraceFilter.Data.DTOs
{
    internal class SignalDto
    {
        [JsonProperty(PropertyName = "sampleRate")]
        public int? SampleRate { get; set; }

        [JsonProperty(PropertyName = "samples")]
        public float[]? Samples { get; set; }
    }
}