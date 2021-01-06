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
    public class DetailViewModel : BaseViewModel
    {
        public Command EditCommand { get; }
        public Command DeleteCommand { get; }
        private EmployeeDAL empDAL;

        public DetailViewModel()
        {
            Title = "Detail Employee";
            empDAL = new EmployeeDAL();
            EditCommand = new Command(async ()=> await EditCommandExecute());
            DeleteCommand = new Command(async ()=> await DeleteCommandExecute());
        }

        async Task DeleteCommandExecute()
        {
            try
            {
                var answer = await Application.Current.MainPage.DisplayAlert("Konfirmasi",
                    "Apakah anda yakin akan delete data?", "Yes", "No");

                if (!answer)
                    return;

                var deleteData = new Employee
                {
                    EmpId = this.EmpId
                };

                var result = empDAL.Delete(deleteData);

                if (result == 1)
                {
                    await Application.Current.MainPage.DisplayAlert("Keterangan",
                      $"Data Employee berhasil di delete", "OK");

                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                        $"Error {ex.Message}", "OK");
            }
        }

        async Task EditCommandExecute()
        {
            try
            {
                var editData = new Employee
                {
                    EmpId = this.EmpId,
                    EmpName = this.EmpName,
                    Department = this.Department,
                    Designation = this.Designation,
                    Qualification = this.Qualification
                };
                var result = empDAL.Edit(editData);
                if (result == 1)
                {
                    //await Application.Current.MainPage.DisplayAlert("Keterangan",
                    //   $"Data Employee {editData.EmpName} berhasil di edit", "OK");

                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                        $"Error {ex.Message}", "OK");
            }
        }

        private int empId;
        public int EmpId
        {
            get { return empId; }
            set { empId = value; SetProperty(ref empId, value); }
        }

        private string empName;
        public string EmpName
        {
            get { return empName; }
            set
            {
                empName = value;
                SetProperty(ref empName, value);
            }
        }

        private string designation;

        public string Designation
        {
            get { return designation; }
            set
            {
                designation = value;
                SetProperty(ref designation, value);
            }
        }

        private string department;
        public string Department
        {
            get { return department; }
            set
            {
                department = value;
                SetProperty(ref department, value);
            }
        }

        private string qualification;
        public string Qualification
        {
            get { return qualification; }
            set
            {
                qualification = value;
                SetProperty(ref qualification, value);
            }
        }
    }
}
