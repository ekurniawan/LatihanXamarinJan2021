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
    public partial class ShowEmployee : ContentPage
    {
        private ShowEmployeeViewModel viewmodel;
        public ShowEmployee()
        {
            InitializeComponent();
            viewmodel = new ShowEmployeeViewModel();
            this.BindingContext = viewmodel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewmodel.GetListEmployeeMethod();
            
        }
    }
}