using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests.CheckList
{
    public class CheckListSaveChecklistRequestDto : BaseSafetyRequestDto
    {
        [JsonProperty("cid")]
        public int Id { get; set; }
        [JsonProperty("rid")]
        public int SurveyId { get; set; }
        [JsonProperty("valor")]
        public string Value { get; set; }
        [JsonProperty("comentario")]
        public string Comment { get; set; }
        [JsonProperty("foto")]
        public string Photo { get; set; }

        public CheckListSaveChecklistRequestDto():base("saveChecklist")
        {

        }

        public CheckListSaveChecklistRequestDto(int id) : base("saveChecklist")
        {
            Id = id;
        }
        public CheckListSaveChecklistRequestDto(int id, int surveyId) : base("saveChecklist")
        {
            Id = id;
            SurveyId = surveyId;
        }
        public CheckListSaveChecklistRequestDto(int id, int surveyId, string value) : base("saveChecklist")
        {
            Id = id;
            SurveyId = surveyId;
            Value = value;
        }
    }
}
