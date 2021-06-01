using SafetyBP.Domain.Enums;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace SafetyBP.Wrappers
{
    public class ModelWrapper<T> : INotifyPropertyChanged
    {

        protected Color GreenColor { get { return Color.FromHex("#259b24"); } }
        protected Color RedColor { get { return Color.FromHex("#fc0025"); } }
        protected Color OrangeColor { get { return Color.FromHex("#f2bf56"); } }

        public CheckListQuestionStatus Status { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public T Model { get; }

        public ModelWrapper(T model)
        {
            Model = model;
        }

        protected virtual void SetValue<TValue>(TValue value, [CallerMemberName] string propertyName = null)
        {
            if(typeof(T).GetProperty(propertyName)!=null) typeof(T).GetProperty(propertyName).SetValue(Model, value);
            OnPropertyChanged(propertyName);
        }

        protected virtual TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
        {
            return (TValue)typeof(T).GetProperty(propertyName).GetValue(Model);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string APropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(APropertyName));

        }
    }
}
