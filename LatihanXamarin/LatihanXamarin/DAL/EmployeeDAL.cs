using LatihanXamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LatihanXamarin.DAL
{
    public class EmployeeDAL
    {
        private SQLiteConnection conn;
        public EmployeeDAL()
        {
            DataAccess da = new DataAccess();
            conn = da.GetConnection();
            conn.CreateTable<Employee>();
        }

        public IEnumerable<Employee> GetAll()
        {
            /*string strSql = @"select * from Employee order by EmpName asc";
            var results = conn.Query<Employee>(strSql);*/
            //var results2 = conn.Table<Employee>().OrderBy(e => e.EmpName);
            var results = from e in conn.Table<Employee>()
                          orderby e.EmpName
                          select e;

            return results;
        }

        public IEnumerable<Employee> GetByName(string name)
        {
            var results = from e in conn.Table<Employee>()
                          where e.EmpName.ToLower().Contains(name.ToLower())
                          orderby e.EmpName
                          select e;

            return results;
        }

        public Employee GetById(int empId)
        {
            var result = (from e in conn.Table<Employee>()
                           where e.EmpId == empId
                           select e).SingleOrDefault();
            return result;
        }

        public int Insert(Employee emp)
        {
            return conn.Insert(emp);
        }

        public int Edit(Employee emp)
        {
            return conn.Update(emp);
        }

        public int Delete(Employee emp)
        {
            return conn.Delete(emp);
        }
    }
}
