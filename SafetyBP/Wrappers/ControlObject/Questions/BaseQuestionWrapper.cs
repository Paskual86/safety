using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SafetyBP.Wrappers.ControlObject.Questions
{
    public class BaseQuestionWrapper<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public T Model { get; }

        public BaseQuestionWrapper(T model)
        {
            Model = model;
        }

        protected virtual void SetValue<TValue>(TValue value, [CallerMemberName] string propertyName = null)
        {
            if (typeof(T).GetProperty(propertyName) != null) typeof(T).GetProperty(propertyName).SetValue(Model, value);
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
