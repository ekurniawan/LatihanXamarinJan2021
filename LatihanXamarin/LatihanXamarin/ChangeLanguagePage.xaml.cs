using LatihanXamarin.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LatihanXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeLanguagePage : ContentPage
    {
        public ChangeLanguagePage()
        {
            InitializeComponent();
        }

        void OnUpdateLangugeClicked(object sender, System.EventArgs e)
        {
            var aturbahasa = string.Empty;
            if (Preferences.ContainsKey("bahasa"))
                aturbahasa = Preferences.Get("bahasa","");

            if (picker.SelectedItem != null)
            {
                /*if (string.IsNullOrEmpty(aturbahasa))
                {
                    aturbahasa = picker.SelectedItem.ToString();
                    Preferences.Set("bahasa", aturbahasa);
                }
                else
                {
                    Preferences.Set("bahasa", aturbahasa);
                }*/

                aturbahasa = picker.SelectedItem.ToString();
                Preferences.Set("bahasa", aturbahasa);

                var language = CultureInfo.GetCultures(CultureTypes.NeutralCultures).ToList().First(element => element.EnglishName.Contains(aturbahasa)); ;
                Thread.CurrentThread.CurrentUICulture = language;
                AppResources.Culture = language;
                App.Current.MainPage = new NavigationPage(new MultilanguagePage());
            }
        }
    }
}