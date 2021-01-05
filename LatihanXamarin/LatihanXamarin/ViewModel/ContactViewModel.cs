using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LatihanXamarin.ViewModel
{
    public class ContactViewModel : INotifyPropertyChanged
    {
        private string name = "Jovan Christoval";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string website = "http://actual-training.com";
        public string Website
        {
            get { return website; }
            set { website = value; }
        }

        private bool bestFriend;

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public bool BestFriend
        {
            get { return bestFriend; }
            set { bestFriend = value; }
        }

       
        public string DisplayMessage
        {
            get {
                return $"{Name} adalah {(bestFriend ? "teman baik" : "bukan teman baik")}";
            }
        }

    }
}
