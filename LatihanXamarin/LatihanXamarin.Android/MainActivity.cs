using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using LatihanXamarin.Models;
using Android.Gms.Common;
using Xamarin.Forms;

namespace LatihanXamarin.Droid
{
    [Activity(Label = "LatihanXamarin", ScreenOrientation=Android.Content.PM.ScreenOrientation.Portrait, Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private const string ChannelId = "ActualSolusi.Channel";

        public static MainActivity Context
        {
            get;
            private set;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Context = this;

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            ImageCircleRenderer.Init();

            LoadApplication(new App());

            var receiver = DependencyService.Get<INotificationReceiver>();
            receiver.RaiseNotificationReceived("Registering...");
            if (IsPlayServicesAvailable(receiver))
            {
                CreateNotificationChannel();
                receiver.RaiseNotificationReceived("Ready...");
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                return;
            }

            var channel = new NotificationChannel(
                ChannelId,
                "Notifications for Actual Solusi",
                NotificationImportance.Default);

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }

        private bool IsPlayServicesAvailable(INotificationReceiver receiver)
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                {
                    receiver.RaiseErrorReceived(GoogleApiAvailability.Instance.GetErrorString(resultCode));
                }
                else
                {
                    receiver.RaiseErrorReceived("This device is not supported");
                    Finish();
                }
                return false;
            }
            else
            {
                receiver.RaiseNotificationReceived("Google Play Services is available.");
                return true;
            }
        }
    }
}