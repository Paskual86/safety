using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests
{
    public abstract class BaseSafetyCheckListRequestDto : BaseSafetyRequestDto {
        [JsonProperty("valor")]
        public string Value { get; set; }
    }
}
