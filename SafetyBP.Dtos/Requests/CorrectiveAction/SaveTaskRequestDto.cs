using Newtonsoft.Json;

namespace SafetyBP.Dtos.Requests.CorrectiveAction
{
    public class SaveTaskRequestDto : BaseSafetyRequestDto
    {
        [JsonProperty("tid")]
        public long Id { get; set; }
        [JsonProperty("estado")]
        public short Status { get; set; }

        public SaveTaskRequestDto():this(0,0)
        {
            
        }

        public SaveTaskRequestDto(long id):this(id,0)
        {

        }

        public SaveTaskRequestDto(long id, short status)
        {
            Id = id;
            Status = status;
            Action = "saveTask";
        }
    }
}
