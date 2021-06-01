using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests
{
    public class SafetyControlObjectRequestSaveInactiveDto : BaseSafetyRequestDto
    {
        [JsonProperty("rid")]
        public int Id { get; set; }

        public SafetyControlObjectRequestSaveInactiveDto()
        {
            Action = "saveInactive";
        }

        public SafetyControlObjectRequestSaveInactiveDto(int id) : this()
        {
            Id = id;
        }
    }
}
