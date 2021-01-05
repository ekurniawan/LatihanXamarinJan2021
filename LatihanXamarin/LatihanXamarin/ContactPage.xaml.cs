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
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
            this.BindingContext = new ContactViewModel();
        }

        private async void btnListImageCell_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListImageCell());
        }
    }
}