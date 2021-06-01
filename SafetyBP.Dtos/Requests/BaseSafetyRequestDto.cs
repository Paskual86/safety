using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests
{
    public abstract class BaseSafetyRequestDto
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("action")]
        public string Action { get; set; }

        public BaseSafetyRequestDto():this(string.Empty)
        {

        }

        public BaseSafetyRequestDto(string action)
        {
            Action = action;
        }
    }
}
