using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests
{
    public class SafetyControlObjectSavePhotoQuestionRequestDto : BaseSafetyRequestDto
    {
        [JsonProperty("rid")]
        public int Id { get; set; }
        [JsonProperty("pid")]
        public int CodeId { get; set; }
        [JsonProperty("foto")]
        public string Photo { get; set; }

        public SafetyControlObjectSavePhotoQuestionRequestDto()
        {
            Action = "saveAnswerPhoto";
        }

        public SafetyControlObjectSavePhotoQuestionRequestDto(int id, int codeId):this()
        {
            Id = id;
            CodeId = codeId;
        }
    }
}
