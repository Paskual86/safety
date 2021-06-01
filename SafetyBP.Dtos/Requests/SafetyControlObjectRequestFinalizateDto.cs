using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests
{
    public class SafetyControlObjectRequestFinalizateDto : BaseSafetyRequestDto
    {
        [JsonProperty("rid")]
        public int Id { get; set; }

        [JsonProperty("critica")]
        public byte Review { get; set; }

        public SafetyControlObjectRequestFinalizateDto()
        {
            Action = "finalizar";
        }

        public SafetyControlObjectRequestFinalizateDto(int id): this()
        {
            Id = id;
        }
    }
}
