using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LatihanXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnSubmit_Clicked(object sender, EventArgs e)
        {
            var firstName = entryFirstName.Text;
            DisplayAlert("Keterangan", $"Nama anda {firstName}", "OK");
        }

        private async void btnContact_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactPage());
        }

        private async void btnCustomList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomPage());
        }

       

        private async void toolbarContact_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactPage());
        }

        private async void toolbarCustom_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomPage());
        }

        private async void toolbarAdd_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Keterangan", "Tambah Data", "OK");
        }

        private async void btnKirimData_Clicked(object sender, EventArgs e)
        {
            var myPage = new ListImageCell(entryData.Text);

            Global.Instance.myData = entryData.Text;

            await Navigation.PushAsync(myPage);
        }

        private async void btnCekAppCurrent_Clicked(object sender, EventArgs e)
        {
            if (!Application.Current.Properties.ContainsKey("data"))
            {
                Application.Current.Properties["data"] = entryData.Text;
                await DisplayAlert("Keterangan", "App Current berhasil dibuat", "OK");
            } 
            else
            {
                var data = Application.Current.Properties["data"].ToString();
                await DisplayAlert("Keterangan", $"Nilainya: {data}", "OK");
            }
        }

        private async void btnBuatPReference_Clicked(object sender, EventArgs e)
        {
            if (!Preferences.ContainsKey("mydata"))
            {
                Preferences.Set("mydata", entryData.Text);
                await DisplayAlert("Keterangan", "Create Preferences", "OK");
            }
            else
            {
                var data = Preferences.Get("mydata", "default");
                await DisplayAlert("Keterangan", $"Data: {data}", "OK");
            }
        }
    }
}
