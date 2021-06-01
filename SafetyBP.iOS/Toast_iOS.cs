using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using SafetyBP.Interfaces;
using SafetyBP.iOS;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(Toast_iOS))]
namespace SafetyBP.iOS
{
    class Toast_iOS : IToast
    {
        const double LONG_DELAY = 3.5;
        const double SHORT_DELAY = 2.0;

        NSTimer alertDelay;
        UIAlertController alert;
        public void Short(string message)
        {
            ShowAlert(message, SHORT_DELAY);
        }

        public void Long(string message)
        {
            ShowAlert(message, LONG_DELAY);
        }

        void ShowAlert(string message, double seconds)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                dismissMessage();
            });
            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        void dismissMessage()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }
            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }
    }
}