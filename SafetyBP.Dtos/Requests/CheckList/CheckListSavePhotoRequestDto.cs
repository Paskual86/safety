using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests.CheckList
{
    public class CheckListSavePhotoRequestDto : BaseSafetyRequestDto
    {
        [JsonProperty("cid")]
        public int Id { get; set; }
        [JsonProperty("rid")]
        public int SurveyId { get; set; }
        [JsonProperty("foto")]
        public string Photo { get; set; }

        public CheckListSavePhotoRequestDto() : base("savePhoto")
        {

        }

        public CheckListSavePhotoRequestDto(int id) : base("savePhoto")
        {
            Id = id;
        }
        public CheckListSavePhotoRequestDto(int id, int surveyId) : base("savePhoto")
        {
            Id = id;
            SurveyId = surveyId;
        }
        public CheckListSavePhotoRequestDto(int id, int surveyId, string photo) : base("savePhoto")
        {
            Id = id;
            SurveyId = surveyId;
            Photo = photo;
        }
    }
}
