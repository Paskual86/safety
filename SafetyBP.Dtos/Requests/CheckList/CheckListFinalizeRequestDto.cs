using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests.CheckList
{
    public class CheckListFinalizeRequestDto : BaseSafetyRequestDto
    {
        [JsonProperty("rid")]
        public int SurveyId { get; set; }

        public CheckListFinalizeRequestDto() : base("finalizar")
        {

        }
        
        public CheckListFinalizeRequestDto(int surveyId) : base("finalizar")
        {
            SurveyId = surveyId;
        }
    }
}
