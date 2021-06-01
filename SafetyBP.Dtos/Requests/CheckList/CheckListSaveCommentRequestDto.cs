using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests.CheckList
{
    public class CheckListSaveCommentRequestDto : BaseSafetyRequestDto
    {
        [JsonProperty("cid")]
        public int Id { get; set; }
        [JsonProperty("rid")]
        public int SurveyId { get; set; }
        [JsonProperty("comentario")]
        public string Comment { get; set; }
        
        public CheckListSaveCommentRequestDto() : base("saveComment")
        {

        }

        public CheckListSaveCommentRequestDto(int id) : base("saveComment")
        {
            Id = id;
        }
        public CheckListSaveCommentRequestDto(int id, int surveyId) : base("saveComment")
        {
            Id = id;
            SurveyId = surveyId;
        }
        public CheckListSaveCommentRequestDto(int id, int surveyId, string comment) : base("saveComment")
        {
            Id = id;
            SurveyId = surveyId;
            Comment = comment;
        }
    }
}
