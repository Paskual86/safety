using Android.Content;
using Android.Speech;
using SafetyBP.Droid;
using SafetyBP.Interfaces;
using System.Windows.Input;

[assembly: Xamarin.Forms.Dependency(typeof(SpeachToTextBusiness))]
namespace SafetyBP.Droid
{
    public class SpeachToTextBusiness : ISpeachToTextBusiness
    {
        private readonly int VOICE = 10;

        public void BeganToRecord(ICommand callback)
        {

            string rec = Android.Content.PM.PackageManager.FeatureMicrophone;
            if (rec != "android.hardware.microphone")
            {
                // no microphone, no recording. Disable the button and output an alert
                /*var alert = new AlertDialog.Builder(recButton.Context);
                alert.SetTitle("You don't seem to have a microphone to record with");
                alert.SetPositiveButton("OK", (sender, e) =>
                {
                    textBox.Text = "No microphone present";
                    recButton.Enabled = false;
                    return;
                });

                alert.Show();*/
            }
            else
            {


                var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
                voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);

                // put a message on the modal dialog
                voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, "Listening");

                // if there is more then 1.5s of silence, consider the speech over
                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
                voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
                voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);

                // you can specify other languages recognised here, for example
                // voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.German);
                // if you wish it to recognise the default Locale language and German
                // if you do use another locale, regional dialects may not be recognised very well

                voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
                MainActivity.Instance.OnActivityResultCommand = callback;
                MainActivity.Instance.StartActivityForResult(voiceIntent, VOICE);
            }
        }

        
    }
}