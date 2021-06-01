using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests
{
    public class SafetyCheckListQuestionSaveCommentRequestDto
    {
        private const string SAVE_COMMENT = "saveComment";

        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("action")]
        public string Action { get; private set; }
        [JsonProperty("rid")]
        public int RelatedId { get; set; }
        [JsonProperty("cid")]
        public int CodeId { get; set; }
        [JsonProperty("comentario")]
        public string Comments { get; set; }

        public SafetyCheckListQuestionSaveCommentRequestDto()
        {
            Action = SAVE_COMMENT;
        }
    }
}
