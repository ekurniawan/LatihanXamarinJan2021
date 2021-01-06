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
    public partial class MultilanguagePage : ContentPage
    {
        public MultilanguagePage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ChangeLanguagePage());
        }
    }
}