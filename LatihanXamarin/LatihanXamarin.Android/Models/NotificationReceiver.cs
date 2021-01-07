using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LatihanXamarin.Droid.Models;
using LatihanXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


[assembly: Xamarin.Forms.Dependency(typeof(NotificationReceiver))]
namespace LatihanXamarin.Droid.Models
{
    public class NotificationReceiver : INotificationReceiver
    {
        public event EventHandler<string> NotificationReceived;
        public event EventHandler<string> ErrorReceived;

        public void RaiseErrorReceived(string message)
        {
            ErrorReceived?.Invoke(this, message);
        }

        public void RaiseNotificationReceived(string message)
        {
            NotificationReceived?.Invoke(this, message);
        }
    }
}