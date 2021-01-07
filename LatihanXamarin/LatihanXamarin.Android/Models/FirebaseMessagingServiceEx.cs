using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;
using LatihanXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsAzure.Messaging;
using Xamarin.Forms;

namespace LatihanXamarin.Droid.Models
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FirebaseMessagingServiceEx : FirebaseMessagingService
    {
        private const string Template = "{\"notification\":{\"body\":\"$(body)\",\"title\":\"$(title)\"},\"data\":{\"title\":\"$(title)\",\"body\":\"$(body)\"}}";

        public override void OnNewToken(string token)
        {
            base.OnNewToken(token);
            System.Diagnostics.Debug.WriteLine(token);

            var hub = new NotificationHub(
                Konstanta.HubName,
                Konstanta.HubConnectionString,
                MainActivity.Context);

            var registration = hub.Register(token, Konstanta.HubTagName);

            var pnsHandle = registration.PNSHandle;
            var templateReg = hub.RegisterTemplate(
                pnsHandle,
                "defaultTemplate",
                Template,
                Konstanta.HubTagName);

            var receiver = DependencyService.Get<INotificationReceiver>();
            receiver.RaiseNotificationReceived("Ready and registered...");
        }

        public override void OnMessageReceived(RemoteMessage remoteMessage)
        {
            base.OnMessageReceived(remoteMessage);

            var receiver = DependencyService.Get<INotificationReceiver>();
            var message = remoteMessage.Data["body"];
            receiver.RaiseNotificationReceived(message);
        }
    }
}