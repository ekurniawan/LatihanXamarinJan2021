using LatihanXamarin.Resources;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LatihanXamarin
{
    //
    public partial class App : Application
    {
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
        public App()
        {
            //Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;
            InitializeComponent();

            /*if (Preferences.ContainsKey("bahasa"))
            {
                var language = CultureInfo.GetCultures(CultureTypes.NeutralCultures).ToList().First(element => element.EnglishName.Contains(Preferences.Get("bahasa", "english")));
                Thread.CurrentThread.CurrentUICulture = language;
                AppResources.Culture = language;
            }*/


            //MainPage = new NavigationPage(new MultilanguagePage());
            MainPage = new NavigationPage(new MyPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
