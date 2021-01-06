using LatihanXamarin.DAL;
using LatihanXamarin.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LatihanXamarin.ViewModel
{
    public class AddEmployeeViewModel : BaseViewModel
    {
        public Command AddCommand { get; }
        public Command CancelCommand { get;}


        public AddEmployeeViewModel()
        {
            Title = "Add Employee";
            AddCommand = new Command(async ()=> await AddEmployeeExecute());
        }

        async Task AddEmployeeExecute()
        {
            EmployeeDAL empDAL = new EmployeeDAL();
            var newEmp = new Employee
            {
                EmpName = this.EmpName,
                Designation = this.Designation,
                Department = this.Department,
                Qualification = this.Qualification
            };

            try
            {
                empDAL.Insert(newEmp);
                await Application.Current.MainPage.DisplayAlert("Keterangan",
                    $"Data Employee {EmpName} berhasil ditambah", "OK");

                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                                    $"Error: {ex.Message}", "OK");
            }
        }

        private string empName;
        public string EmpName
        {
            get { return empName; }
            set { 
                empName = value;
                SetProperty(ref empName, value);
            }
        }

        private string designation;

        public string Designation
        {
            get { return designation; }
            set { 
                designation = value;
                SetProperty(ref designation, value);
            }
        }


        private string department;
        public string Department
        {
            get { return department; }
            set { 
                department = value;
                SetProperty(ref department, value);
            }
        }

        private string qualification;
        public string Qualification
        {
            get { return qualification; }
            set { 
                qualification = value;
                SetProperty(ref qualification, value);
            }
        }

    }
}
