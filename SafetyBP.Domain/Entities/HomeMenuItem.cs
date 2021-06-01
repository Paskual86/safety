using SafetyBP.Domain.Enums;

namespace SafetyBP.Domain.Entities
{
    public class HomeMenuItem
    {
        public HomeMenu Id { get; set; }
        public string Text { get; set; }
        public object TextColor { get; set; }
        public object BackgroundColor { get; set; }
        public object Imagen { get; set; }
        public bool Enabled { get; set; }

        public HomeMenuItem()
        {
            Enabled = false;
        }
    }    
}
