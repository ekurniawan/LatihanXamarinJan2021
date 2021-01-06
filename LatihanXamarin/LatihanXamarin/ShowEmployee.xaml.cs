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

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var data = (Employee)e.Item;
            var viewmodel = new DetailViewModel { 
                EmpId = data.EmpId,
                EmpName = data.EmpName,
                Designation = data.Designation,
                Qualification = data.Qualification,
                Department = data.Department
            };
            var detailPage = new DetailEmployee();
            detailPage.BindingContext = viewmodel;
            await Navigation.PushAsync(detailPage);
        }
    }
}