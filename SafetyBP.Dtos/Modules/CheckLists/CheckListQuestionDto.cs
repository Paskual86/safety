using Newtonsoft.Json;
using SafetyBP.Dtos.Enums;
using System.Collections.Generic;

namespace SafetyBP.Dtos
{
    public class CheckListQuestionDto
    {

        [JsonProperty("cid")]
        public int Code { get; set; }
        [JsonProperty("rid")]
        public int RelatedId { get; set; }
        [JsonProperty("tipo")]
        public CheckListQuestionTypes Type { get; set; }

        [JsonProperty("alerta")]
        public byte IsAlert { get; set; }

        [JsonProperty("foto")]
        public byte PhotoRequired { get; set; }

        [JsonProperty("critica")]
        public byte IsCritica { get; set; }
        [JsonProperty("negativos")]
        public IList<int> NegativeValues { get; set; }
        [JsonProperty("pregunta")]
        public string Name { get; set; }
        [JsonProperty("respuesta")]
        public string Value { get; set; }
    }
}
