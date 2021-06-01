using SQLite;

namespace SafetyBP.Domain.PreviousEntities
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Cliente { get; set; }
        public string Foto { get; set; }
        public string Token { get; set; }
    }
}
