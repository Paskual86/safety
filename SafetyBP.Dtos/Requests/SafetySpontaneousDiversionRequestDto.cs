using Newtonsoft.Json;
using System.Collections.Generic;

namespace SafetyBP.Dtos.Requests
{
    public class SafetySpontaneousDiversionRequestDto
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("desvios")]
        public IEnumerable<SafetySpontaneousDiversionDetailRequestDto> Diversion { get; set; }
    }
}
