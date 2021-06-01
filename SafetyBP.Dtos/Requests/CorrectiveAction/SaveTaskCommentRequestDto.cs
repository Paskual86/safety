using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests.CorrectiveAction
{
    public class SaveTaskCommentRequestDto : BaseSafetyRequestDto
    {
        [JsonProperty("tid")]
        public long Id { get; set; }
        [JsonProperty("comentario")]
        public string Content { get; set; }

        public SaveTaskCommentRequestDto() : this(0, string.Empty)
        {

        }

        public SaveTaskCommentRequestDto(long id) : this(id, string.Empty)
        {

        }

        public SaveTaskCommentRequestDto(long id, string comment)
        {
            Id = id;
            Content = comment;
            Action = "saveComment";
        }
    }
}
