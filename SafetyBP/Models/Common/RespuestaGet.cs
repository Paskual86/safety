using SafetyBP.Domain.Entities;
using System.Net;

namespace SafetyBP.Models.Common
{
    // CLASES PARA EL WEBSERVICE
    public class RespuestaGet
    {
        public HttpStatusCode StatusCode { get; set; }
        public Domain.Entities.Tokens Token { get; set; }
        public Usuarios Usuario { get; set; }
        public Error Error { get; set; }
    }
}
