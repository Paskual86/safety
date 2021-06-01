using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests
{
    public class SafetyCheckListQuestionRequestDto : BaseSafetyCheckListRequestDto
    {
        [JsonProperty("rid")]
        public string RelatedId { get; set; }
        [JsonProperty("cid")]
        public string CodeId { get; set; }
        [JsonProperty("comentario")]
        public string Comments { get; set; }
        [JsonProperty("foto")]
        public string PhotoContent { get; set; }
    }
}
