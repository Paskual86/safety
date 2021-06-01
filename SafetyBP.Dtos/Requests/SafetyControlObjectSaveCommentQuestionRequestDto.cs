using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests
{
    public class SafetyControlObjectSaveCommentQuestionRequestDto : BaseSafetyRequestDto
    {
        [JsonProperty("rid")]
        public int Id { get; set; }
        [JsonProperty("pid")]
        public int CodeId { get; set; }
        [JsonProperty("comentario")]
        public string Comment { get; set; }

        public SafetyControlObjectSaveCommentQuestionRequestDto()
        {
            Action = "saveAnswerComment";
        }
        public SafetyControlObjectSaveCommentQuestionRequestDto(int id, int codeId) : this()
        {
            Id = id;
            CodeId = codeId;
        }
    }
}
