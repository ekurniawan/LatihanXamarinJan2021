﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LatihanXamarin
{
    //
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CustomPage();
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
