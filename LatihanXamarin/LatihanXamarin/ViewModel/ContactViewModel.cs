using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LatihanXamarin.ViewModel
{
    public class ContactViewModel : INotifyPropertyChanged
    {
        private string name = "Jovan Christoval";
        public string Name
        {
            get { return name; }
            set { 
                name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        private string website = "http://actual-training.com";
        public string Website
        {
            get { return website; }
            set { 
                website = value;
                OnPropertyChanged(nameof(Website));
                OnPropertyChanged(nameof(DisplayMessage));
            }
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
            set { 
                bestFriend = value;
                OnPropertyChanged(nameof(BestFriend));
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

       
        public string DisplayMessage
        {
            get {
                return $"{Name} adalah {(bestFriend ? "teman baik" : "bukan teman baik")} website: {Website}";
            }
        }

        private bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set { 
                isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
                //BukaWebsiteCommand.ChangeCanExecute();
                SimpanDataContact.ChangeCanExecute();
            }
        }


        public Command BukaWebsiteCommand { get; set; }
        public Command SimpanDataContact { get; set; }

        public ContactViewModel()
        {
            BukaWebsiteCommand = new Command(BukaWebsite);
            SimpanDataContact = new Command(async ()=>await SimpanData(),()=>!IsBusy);
        }

        async Task SimpanData()
        {
            IsBusy = true;
            await Task.Delay(5000);
            IsBusy = false;

            await Application.Current.MainPage.DisplayAlert("Simpan", "Data Kontak berhasil disimpan", "OK");
        }

        void BukaWebsite()
        {
            try
            {
                Device.OpenUri(new Uri(website));
            }
            catch (Exception ex)
            {

            }
        }
    }
}
