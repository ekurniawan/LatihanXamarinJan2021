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

        private void lstData_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var data = (ListItem)e.Item;
            DisplayAlert("Keterangan", $"Title = {data.Title} Desc: {data.Description}", "OK");
        }
    }
}