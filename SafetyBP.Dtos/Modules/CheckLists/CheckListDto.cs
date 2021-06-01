using Newtonsoft.Json;
using System.Collections.Generic;

namespace SafetyBP.Dtos
{
    public class CheckListDto
    {
        [JsonProperty("sid")]
        public int Id { get; set; }
        [JsonProperty("sector")]
        public string Sector { get; set; }
        [JsonProperty("checklist")]
        public ICollection<CheckListDetailDto> Details { get; set; }
    }
}
