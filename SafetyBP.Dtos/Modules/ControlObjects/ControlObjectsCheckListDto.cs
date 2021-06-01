using Newtonsoft.Json;
using SafetyBP.Dtos.Enums;
using System.Collections.Generic;

namespace SafetyBP.Dtos
{
    public class ControlObjectsCheckListDto
    {
        [JsonProperty("cid")]
        public int Id { get; set; }
        [JsonProperty("rid")]
        public int SurveyId { get; set; }
        [JsonProperty("tipo")]
        public CheckListQuestionTypes Type { get; set; }
        [JsonProperty("alerta")]
        public byte IsAlert { get; set; }
        [JsonProperty("foto")]
        public byte IsPhotoRequired { get; set; }
        [JsonProperty("critica")]
        public byte IsCritica { get; set; }
        [JsonProperty("negativos")]
        public IList<int> NegativeValues { get; set; }
        [JsonProperty("pregunta")]
        public string QuestionDescription { get; set; }
        [JsonProperty("respuesta")]
        public string Answer { get; set; }
    }
}
