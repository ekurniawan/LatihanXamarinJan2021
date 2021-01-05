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
    public partial class ListImageCell : ContentPage
    {
        public ListImageCell()
        {
            InitializeComponent();

            List<ListItem> lstItems = new List<ListItem>
            {
                new ListItem{Title="Xamarin for Android",Description="Xamarin for Android",
                 Source="https://freepngimg.com/thumb/youtube/6-2-youtube-png-picture.png"},
                new ListItem{Title="Xamarin for IOS",Description="Xamarin for IOS",
                 Source="https://freepngimg.com/thumb/youtube/6-2-youtube-png-picture.png"},
                new ListItem{Title="Xamarin Forms",Description="Xamarin Forms",
                    Source="https://freepngimg.com/thumb/youtube/6-2-youtube-png-picture.png"}
            };
            lstData.ItemsSource = lstItems;
        }

        private string _data;
        public ListImageCell(string data)
        {
            InitializeComponent();

            List<ListItem> lstItems = new List<ListItem>
            {
                new ListItem{Title="Xamarin for Android",Description="Xamarin for Android",
                 Source="https://freepngimg.com/thumb/youtube/6-2-youtube-png-picture.png"},
                new ListItem{Title="Xamarin for IOS",Description="Xamarin for IOS",
                 Source="https://freepngimg.com/thumb/youtube/6-2-youtube-png-picture.png"},
                new ListItem{Title="Xamarin Forms",Description="Xamarin Forms",
                    Source="https://freepngimg.com/thumb/youtube/6-2-youtube-png-picture.png"}
            };
            lstData.ItemsSource = lstItems;

            _data = data;
            lblKeterangan.Text = $"Data yg dikirimkan {_data}";
        }

        private void lstData_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var data = (ListItem)e.Item;
            DisplayAlert("Keterangan", $"Title = {data.Title} Desc: {data.Description}", "OK");
        }

        private async void btnCekGlobal_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Keterangan", $"Nilai global {Global.Instance.myData}", "OK");
        }

        private async void btnCekAppCurrent_Clicked(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("data"))
            {
                await DisplayAlert("App Current", $"Data : {Application.Current.Properties["data"].ToString()}", "OK");
            }
            else
            {
                await DisplayAlert("App Current", "Kosong", "OK");
            }
        }
    }
}