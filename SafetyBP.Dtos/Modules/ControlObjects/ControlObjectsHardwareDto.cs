using Newtonsoft.Json;
using System.Collections.Generic;

namespace SafetyBP.Dtos
{
    public class ControlObjectsHardwareDto
    {
        [JsonProperty("eid")]
        public int Id { get; set; }

        [JsonProperty("qr")]
        public int QrId { get; set; }

        [JsonProperty("equipo")]
        public string Name { get; set; }
        [JsonProperty("sectores")]
        public IList<ControlObjectsSectorsDto> Sectors { get; set; }
    }
}
