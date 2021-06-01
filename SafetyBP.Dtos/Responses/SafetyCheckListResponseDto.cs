using Newtonsoft.Json;

namespace SafetyBP.Dtos.Responses
{
    public class SafetyCheckListResponseDto
    {
        [JsonProperty("status")]
        public bool Status { get; set; }
        [JsonProperty("response")]
        public string Response { get; set; }
    }
}
