using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests
{
    public class SafetyTaskCheckRequestDto : BaseSafetyCheckListRequestDto
    {
        [JsonProperty("cid")]
        public int Id { get; set; }
        [JsonProperty("estado")]
        public string Status { get; set; }

        public SafetyTaskCheckRequestDto()
        {
            Action = "saveTask";
        }
    }

}
