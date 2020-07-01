using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using EnFiveSales.DataService;
using EnFiveSales.iOS.DependencyServices;
using Xamarin.Forms.Platform.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(MessageIOS))]
namespace EnFiveSales.iOS.DependencyServices
{
    public class MessageIOS : IMessage
    {
        const double LONG_DELAY = 3.5;
        const double SHORT_DELAY = 2.0;

        NSTimer alertDelay;
        UIAlertController alert;

        public void LongAlert(string message)
        {
            ShowAlert(message, LONG_DELAY);
        }
        public void ShortAlert(string message)
        {
            ShowAlert(message, SHORT_DELAY);
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

        const string NotificationKey = "my_notification_channel";

        public void DisplayPush(string message)
        {
            var notification = new UILocalNotification
            {
                AlertTitle = "Test",
                AlertBody = message,
                SoundName = UILocalNotification.DefaultSoundName,
                FireDate = DateTime.Now.ToNSDate(),
                RepeatInterval = NSCalendarUnit.Minute,

                UserInfo = NSDictionary.FromObjectAndKey(NSObject.FromObject(1), NSObject.FromObject(NotificationKey))
            };
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
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