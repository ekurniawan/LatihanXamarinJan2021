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
    public partial class MyTabbedPage : TabbedPage
    {
        public MyTabbedPage()
        {
            InitializeComponent();
        }

        private async void btnActionSheet_Clicked(object sender, EventArgs e)
        {
            
            var action = await DisplayActionSheet("Share to:", "Cancel", null, "Facebook", "Twitter", "Tiktok", "Instagram");
            await DisplayAlert("Pilihan", $"Pilihan {action}", "OK");
        }

        private async void btnDisplayAlert_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayAlert("Konfirmasi", "Mau delete data?", "Yes", "No");
            await DisplayAlert("Jawaban", $"Anda menjawab {action}","OK");
        }
    }
}