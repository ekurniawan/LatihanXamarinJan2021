﻿using LatihanXamarin.ViewModel;
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
    public partial class AddEmployee : ContentPage
    {
        
        public AddEmployee()
        {
            InitializeComponent();
            this.BindingContext = new AddEmployeeViewModel();
        }

    }
}