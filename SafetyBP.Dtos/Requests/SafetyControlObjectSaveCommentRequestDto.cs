using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests
{
    public class SafetyControlObjectSaveCommentRequestDto : BaseSafetyRequestDto
    {
        [JsonProperty("rid")]
        public int Id { get; set; }
        [JsonProperty("cid")]
        public int CodeId { get; set; }
        [JsonProperty("comentario")]
        public string Comment { get; set; }

        public SafetyControlObjectSaveCommentRequestDto()
        {
            Action = "saveComment";
        }

        public SafetyControlObjectSaveCommentRequestDto(int id, int codeId) : this()
        {
            Id = id;
            CodeId = codeId;
        }
    }
}
