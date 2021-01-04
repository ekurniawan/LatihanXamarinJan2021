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
    public partial class SimpleListView : ContentPage
    {
        public SimpleListView()
        {
            InitializeComponent();
            List<string> items = new List<string>
            {
                "First","Second","Third"
            };
            lstData.ItemsSource = items;

            lstData.ItemTapped += LstData_ItemTapped;
        }

        private void LstData_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            string data = e.Item.ToString();
            DisplayAlert("Tapped", $"Anda memilih: {data}", "OK");

            ((ListView)sender).SelectedItem = null;
        }
    }
}