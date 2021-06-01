using System.Net;

namespace SafetyBP.Models.Common
{
    public class RespuestaPost
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string TId { get; set; }
        public string Estado { get; set; }
        public Error Error { get; set; }
    }
}
