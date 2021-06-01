using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests
{

    public class SettleSafetyCheckListRequestDto : BaseSafetyCheckListRequestDto
    {
        [JsonProperty("rid")]
        public string Id { get; set; }
    }
}
