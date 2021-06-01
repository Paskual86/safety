using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests
{
    public class SafetyCheckListQuestionSavePhotoRequestDto
    {
        private const string SAVE_PHOTO = "savePhoto";


        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("action")]
        public string Action { get; private set; }
        [JsonProperty("rid")]
        public int RelatedId { get; set; }

        [JsonProperty("cid")]
        public int CodeId { get; set; }
        [JsonProperty("foto")]
        public string PhotoContent { get; set; }

        

        public SafetyCheckListQuestionSavePhotoRequestDto()
        {
            Action = SAVE_PHOTO;
        }
    }
}
