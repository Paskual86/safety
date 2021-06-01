using Newtonsoft.Json;
using System.Collections.Generic;

namespace SafetyBP.Dtos
{
    public class CheckListDetailDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("checklist")]
        public string Name { get; set; }
        [JsonProperty("fecha")]
        public string Date { get; set; }
        [JsonProperty("preguntas")]
        public ICollection<CheckListQuestionDto> Questions { get; set; }
    }
}
