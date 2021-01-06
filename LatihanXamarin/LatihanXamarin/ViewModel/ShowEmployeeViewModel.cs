using LatihanXamarin.DAL;
using LatihanXamarin.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace LatihanXamarin.ViewModel
{
    public class ShowEmployeeViewModel : BaseViewModel
    {
        private EmployeeDAL _empDAL;
        public ObservableCollection<Employee> ListEmployees { get; set; }
        public Command GetListEmployees { get; }
        public Command AddEmployeeCommand { get; }

        public ShowEmployeeViewModel()
        {
            Title = "Show Employee";
            _empDAL = new EmployeeDAL();
            IsBusy = false;
            ListEmployees = new ObservableCollection<Employee>();
            GetListEmployees = new Command(async ()=> await GetListEmployeeMethod());
            AddEmployeeCommand = new Command(async () => await AddEmployeeCommandExecute());
            //Task.Run(()=>GetListEmployeeMethod()).Wait();
        }

        async Task AddEmployeeCommandExecute()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddEmployee());
        }

        public async Task GetListEmployeeMethod()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            await Task.Delay(1000);
            
            try
            {
                ListEmployees.Clear();
                var results = _empDAL.GetAll();
                foreach (var emp in results)
                {
                    ListEmployees.Add(emp);
                }
                
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"{ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }

            
        }
    }
}
