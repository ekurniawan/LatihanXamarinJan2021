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
            btnSubmit.Clicked += btnSubmit_Clicked;
        }

        private void btnSubmit_Clicked(object sender, EventArgs e)
        {
            var firstName = entryFirstName.Text;
            DisplayAlert("Keterangan", $"Nama anda {firstName}", "OK");
        }
    }
}
