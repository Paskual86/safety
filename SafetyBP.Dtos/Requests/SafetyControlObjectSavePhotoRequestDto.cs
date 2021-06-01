using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests
{
    public class SafetyControlObjectSavePhotoRequestDto : BaseSafetyRequestDto
    {
        [JsonProperty("rid")]
        public int Id { get; set; }
        [JsonProperty("cid")]
        public int CodeId { get; set; }
        [JsonProperty("foto")]
        public string Photo { get; set; }

        public SafetyControlObjectSavePhotoRequestDto()
        {
            Action = "savePhoto";
        }

        public SafetyControlObjectSavePhotoRequestDto(int id, int codeId) : this()
        {
            Id = id;
            CodeId = codeId;
        }
    }
}
