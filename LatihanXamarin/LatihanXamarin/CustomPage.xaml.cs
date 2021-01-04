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
    public partial class CustomPage : ContentPage
    {
        public CustomPage()
        {
            InitializeComponent();

            List<ListItem> lstItems = new List<ListItem>
            {
                new ListItem{Title="Xamarin for Android",Description="Xamarin for Android",
                 Source="https://freepngimg.com/thumb/youtube/6-2-youtube-png-picture.png",Price="10"},
                new ListItem{Title="Xamarin for IOS",Description="Xamarin for IOS",
                 Source="https://freepngimg.com/thumb/youtube/6-2-youtube-png-picture.png",Price="12"},
                new ListItem{Title="Xamarin Forms",Description="Xamarin Forms",
                    Source="https://freepngimg.com/thumb/youtube/6-2-youtube-png-picture.png",Price="15"}
            };

            lstData.ItemsSource = lstItems;
        }

        private void lstData_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var data = (ListItem)e.Item;
            DisplayAlert("Keterangan", $"Title: {data.Title} Price: {data.Price}", "OK");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var myButton = (Button)sender;
            string data = myButton.CommandParameter.ToString();
            DisplayAlert("Keterangan", $"ID: {data}","OK");
        }
    }
}