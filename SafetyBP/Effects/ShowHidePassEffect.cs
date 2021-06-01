using Xamarin.Forms;

namespace SafetyBP.Effects
{
    public class ShowHidePassEffect : RoutingEffect
    {
        public string EntryText { get; set; }
        public ShowHidePassEffect() : base("SafetyBP.Droid.Effects.ShowHidePassEffect") { }
    }
}
