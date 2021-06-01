using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests.CorrectiveAction
{
    public class SaveTaskPhotoRequestDto : BaseSafetyRequestDto
    {
        [JsonProperty("tid")]
        public long Id { get; set; }
        [JsonProperty("foto")]
        public string Content { get; set; }

        public SaveTaskPhotoRequestDto() : this(0, string.Empty)
        {

        }

        public SaveTaskPhotoRequestDto(long id) : this(id, string.Empty)
        {

        }

        public SaveTaskPhotoRequestDto(long id, string photo)
        {
            Id = id;
            Content = photo;
            Action = "savePhoto";
        }
    }
}
