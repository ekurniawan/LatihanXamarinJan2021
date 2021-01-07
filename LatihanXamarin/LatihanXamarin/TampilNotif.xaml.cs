using LatihanXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LatihanXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TampilNotif : ContentPage
    {
        private readonly INotificationReceiver _notificationsReceiver;
        public TampilNotif()
        {
            _notificationsReceiver = DependencyService.Get<INotificationReceiver>();
            _notificationsReceiver.NotificationReceived += NotificationReceiver_NotificationReceived;
            _notificationsReceiver.ErrorReceived += NotificationReceiver_ErrorReceived;

            InitializeComponent();
        }

        private void NotificationReceiver_ErrorReceived(object sender, string e)
        {
            Dispatcher.BeginInvokeOnMainThread(() =>
            {
                MainLabel.TextColor = Color.Red;
                MainLabel.Text = e;
            });
        }

        private void NotificationReceiver_NotificationReceived(object sender, string e)
        {
            Dispatcher.BeginInvokeOnMainThread(() =>
            {
                MainLabel.TextColor = Color.Black;
                MainLabel.Text = e;
            });
        }
    }
}