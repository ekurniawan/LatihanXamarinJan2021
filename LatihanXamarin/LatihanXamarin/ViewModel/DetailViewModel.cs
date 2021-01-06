using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LatihanXamarin.ViewModel
{
    public class DetailViewModel : BaseViewModel
    {
        public DetailViewModel()
        {

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
