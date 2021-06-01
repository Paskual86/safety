using Newtonsoft.Json;

namespace SafetyBP.Dtos
{
    public class SynchronizationDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("nombre")]
        public string Name { get; set; }
        [JsonProperty("apellido")]
        public string Lastname { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("cliente")]
        public int ClientId { get; set; }
        [JsonProperty("foto")]
        public string PhotoUrl { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("db")]
        public ContentModelDto Content { get; set; }
    }
        
}
