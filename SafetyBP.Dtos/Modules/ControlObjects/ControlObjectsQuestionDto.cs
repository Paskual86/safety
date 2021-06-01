using Newtonsoft.Json;
using SafetyBP.Dtos.Enums;

namespace SafetyBP.Dtos
{
    public class ControlObjectsQuestionDto
    {
        [JsonProperty("pid")]
        public int Id { get; set; }
        [JsonProperty("rid")]
        public int SurveyId { get; set; }
        [JsonProperty("tipo")]
        public CheckListQuestionTypes Type { get; set; }
        [JsonProperty("alerta")]
        public byte IsAlert { get; set; }
        [JsonProperty("foto")]
        public byte IsPhotoRequired { get; set; }
        [JsonProperty("pregunta")]
        public string QuestionDescription { get; set; }
        [JsonProperty("respuesta")]
        public string Answer { get; set; }
    }
}
