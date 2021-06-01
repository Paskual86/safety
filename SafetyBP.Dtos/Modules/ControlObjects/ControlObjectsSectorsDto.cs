using Newtonsoft.Json;
using System.Collections.Generic;

namespace SafetyBP.Dtos
{
    public class ControlObjectsSectorsDto
    {

        [JsonProperty("sid")]
        public int Id { get; set; }
        [JsonProperty("rid")]
        public int SurveyId { get; set; }
        [JsonProperty("qr")]
        public int HardwareQrId { get; set; }
        [JsonProperty("eid")]
        public int HardwareId { get; set; }
        [JsonProperty("equipo")]
        public string HardwareName { get; set; }

        [JsonProperty("sector")]
        public string Name { get; set; }

        [JsonProperty("edificio")]
        public string Place { get; set; }
        [JsonProperty("relevamientos")]
        public IList<ControlObjectsSurveyDto> Surveys { get; set; }
    }
}
