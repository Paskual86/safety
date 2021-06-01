using SafetyBP.Domain.Enums;

namespace SafetyBP.Domain.Models
{
    public class SafetySpontaneousDiversion
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public int SectorId { get; set; }
        public SpontaneousDiversionRisk Risk { get; set; }
        public string Photo { get; set; }
        public string Comment { get; set; }
        public bool Synchronized { get; set; }
        public byte Status { get; set; } // Posible values 0 - Pendiente 1 - Resuelto
        public string RoundName { get; set; } //

        public virtual SafetySector Sector { get; set; }
        public SafetySpontaneousDiversion()
        {
            Synchronized = false;
            Reason = string.Empty;
            Photo = string.Empty;
            Comment = string.Empty;

            RoundName = "Ronda 1";
        }
    }
}
