using LatihanXamarin.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LatihanXamarin.ViewModel
{
    public class ListItemViewModel : BaseViewModel
    {
        public ObservableCollection<ListItem> ListItems { get; set; }
        public ICommand GetListItems { get; }

        public ListItemViewModel()
        {
            Title = "Custom List View";
            ListItems = new ObservableCollection<ListItem>();
            IsBusy = false;
            Task.Run(()=>this.GetListItemsMethod()).Wait();
            GetListItems = new Command(async ()=>await GetListItemsMethod());
        }

        async Task GetListItemsMethod()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            await Task.Delay(4000);

            try
            {
                var data1 = new ListItem
                {
                    Title = "Xamarin for Android",
                    Description = "Xamarin for Android",
                    Source = "https://freepngimg.com/thumb/youtube/6-2-youtube-png-picture.png",
                    Price = "10"
                };
                var data2 = new ListItem
                {
                    Title = "Xamarin for IOS",
                    Description = "Xamarin for IOS",
                    Source = "https://freepngimg.com/thumb/youtube/6-2-youtube-png-picture.png",
                    Price = "12"
                };
                var data3 = new ListItem
                {
                    Title = "Xamarin Forms",
                    Description = "Xamarin Forms",
                    Source = "https://freepngimg.com/thumb/youtube/6-2-youtube-png-picture.png",
                    Price = "15"
                };
                ListItems.Add(data1);
                ListItems.Add(data2);
                ListItems.Add(data3);

                //Application.Current.MainPage.DisplayAlert("Simpan", "Data Kontak berhasil disimpan", "OK");
            }
            catch (Exception)
            {
                
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
