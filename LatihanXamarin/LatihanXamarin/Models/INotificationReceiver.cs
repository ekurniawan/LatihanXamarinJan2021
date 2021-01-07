using System;
using System.Collections.Generic;
using System.Text;

namespace LatihanXamarin.Models
{
    public interface INotificationReceiver
    {
        event EventHandler<string> NotificationReceived;
        event EventHandler<string> ErrorReceived;
        void RaiseNotificationReceived(string message);
        void RaiseErrorReceived(string message);
    }
}
