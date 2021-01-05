using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            await Navigation.PushAsync(myPage);
        }
    }
}
