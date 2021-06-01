using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests
{
    public class SafetyPhotoRequestDto : BaseSafetyCheckListRequestDto
    {
        [JsonProperty("cid")]
        public int Id { get; set; }
        [JsonProperty("foto")]
        public string Photo { get; set; }

        public SafetyPhotoRequestDto()
        {
            Action = "savePhoto";
        }
    }

}
