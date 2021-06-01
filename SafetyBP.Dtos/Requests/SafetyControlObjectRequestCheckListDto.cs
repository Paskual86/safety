using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests
{
    public class SafetyControlObjectRequestCheckListDto : BaseSafetyRequestDto
    {
        [JsonProperty("rid")]
        public int Id { get; set; }
        [JsonProperty("cid")]
        public int CodeId { get; set; }
        [JsonProperty("valor")]
        public string Value { get; set; }
        [JsonProperty("foto")]
        public string Photo { get; set; }

        [JsonProperty("comentario")]
        public string Comment { get; set; }

        public SafetyControlObjectRequestCheckListDto()
        {
            Action = "saveChecklist";
        }

        public SafetyControlObjectRequestCheckListDto(int id, int codeId) : this()
        {
            Id = id;
            CodeId = codeId;
        }
    }
}
