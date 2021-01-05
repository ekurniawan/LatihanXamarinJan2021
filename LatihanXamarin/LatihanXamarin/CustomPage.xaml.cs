using LatihanXamarin.Models;
using LatihanXamarin.ViewModel;
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
            this.BindingContext = new ListItemViewModel();
        }

        private void lstData_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            /*var data = (ListItem)e.Item;
            DisplayAlert("Keterangan", $"Title: {data.Title} Price: {data.Price}", "OK");*/
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var myButton = (Button)sender;
            string data = myButton.CommandParameter.ToString();
            DisplayAlert("Keterangan", $"ID: {data}","OK");
        }
    }
}