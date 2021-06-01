using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests
{
    public class SafetyCommentRequestDto : BaseSafetyCheckListRequestDto
    {
        [JsonProperty("cid")]
        public int Id { get; set; }
        [JsonProperty("comentario")]
        public string Comment { get; set; }

        public SafetyCommentRequestDto()
        {
            Action = "saveComment";
        }
    }

}
