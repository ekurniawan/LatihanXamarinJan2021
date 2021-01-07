using LatihanXamarin.Models;
using LatihanXamarin.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LatihanXamarin.ViewModel
{
    public class ShowEmployeePageViewModel : BaseViewModel
    {
        private EmployeeServices _empService;
        public ObservableCollection<Employee> ListEmployees { get; set; }
        public Command GetListEmployees { get; }
        public Command AddEmployeeCommand { get; }

        public ShowEmployeePageViewModel()
        {
            Title = "Show Employee";
            _empService = new EmployeeServices();
            IsBusy = false;
            ListEmployees = new ObservableCollection<Employee>();
            GetListEmployees = new Command(async () => await GetListEmployeeMethod());
            AddEmployeeCommand = new Command(async () => await AddEmployeeCommandExecute());
            Task.Run(()=>GetListEmployeeMethod()).Wait();

            //GetListEmployeeMethod().GetAwaiter();
        }


        //public async Task DeleteCommandExecute()
        //{
        //    try
        //    {
        //        var answer = await Application.Current.MainPage.DisplayAlert("Konfirmasi",
        //            "Apakah anda yakin akan delete data?", "Yes", "No");

        //        if (!answer)
        //            return;

        //        var deleteData = new Employee
        //        {
        //            EmpId = this.EmpId
        //        };

        //        var result = _empDAL.Delete(deleteData);

        //        if (result == 1)
        //        {
        //            await Application.Current.MainPage.DisplayAlert("Keterangan",
        //              $"Data Employee berhasil di delete", "OK");

        //            await Application.Current.MainPage.Navigation.PopAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Error",
        //                $"Error {ex.Message}", "OK");
        //    }
        //}

        private int empId;
        public int EmpId
        {
            get { return empId; }
            set { empId = value; SetProperty(ref empId, value); }
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

            //await Task.Delay(500);

            try
            {
                ListEmployees.Clear();
                var results = await _empService.GetAll();
                foreach (var emp in results)
                {
                    ListEmployees.Add(emp);
                }
                IsBusy = false;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"{ex.Message}", "OK");
            }
        }
    }
}
