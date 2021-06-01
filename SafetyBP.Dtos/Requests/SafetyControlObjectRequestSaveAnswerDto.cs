using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests
{
    public class SafetyControlObjectRequestSaveAnswerDto : BaseSafetyRequestDto
    {
        [JsonProperty("rid")]
        public int Id { get; set; }
        [JsonProperty("pid")]
        public int Pid { get; set; }
        [JsonProperty("respuesta_texto")]
        public string Answer { get; set; }

        [JsonProperty("respuesta_fecha")]
        public string AnswerDate { get; set; }

        [JsonProperty("foto")]
        public string Photo { get; set; }

        [JsonProperty("comentario")]
        public string Comment { get; set; }

        public SafetyControlObjectRequestSaveAnswerDto()
        {
            Action = "saveAnswer";
        }

        public SafetyControlObjectRequestSaveAnswerDto(int id, int pid): this()
        {
            Id = id;
            Pid = pid;
        }
    }
}
