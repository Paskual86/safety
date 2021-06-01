using Android.Widget;
using SafetyBP.Droid;
using SafetyBP.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(Toast_Android))]
namespace SafetyBP.Droid
{
    class Toast_Android : IToast
    {
        public void Long(string mensaje)
        {
            Toast.MakeText(Android.App.Application.Context, mensaje, ToastLength.Long).Show();
        }

        public void Short(string mensaje)
        {
            Toast.MakeText(Android.App.Application.Context, mensaje, ToastLength.Short).Show();
        }
    }
}