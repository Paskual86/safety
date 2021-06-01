using Xamarin.Forms;

namespace SafetyBP.Domain.Wrappers
{
    public class WrapperAddColor<T>
    {
        public T Value { get; set; }
        public Color Color { get; set; }

        public WrapperAddColor(T value)
        {
            Value = value;
        }
    }
}
