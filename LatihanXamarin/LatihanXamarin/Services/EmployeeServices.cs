using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LatihanXamarin.Models;
using RestSharp;

namespace LatihanXamarin.Services
{
    public class EmployeeServices
    {
        private RestClient _restClient;
        public EmployeeServices()
        {
            _restClient = new RestClient
            {
                BaseUrl = new Uri("https://actualbackendservices.azurewebsites.net")
            };
        }

        public EmployeeServices(string token)
        {
            _restClient = new RestClient
            {
                BaseUrl = new Uri("https://actualbackendservices.azurewebsites.net/")
            };
            
            _restClient.AddDefaultHeader("Authorization", token);

            //401 - unauthorize
        }



        public async Task<IEnumerable<Employee>> GetAll()
        {
            var request = new RestRequest("api/Employees", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            var response = await _restClient.ExecuteAsync<List<Employee>>(request);
            if (response.Data == null)
            {
                throw new Exception($"Error: {response.ErrorMessage}");
            }
            return response.Data;
        }

        public async Task<Employee> Insert(Employee emp)
        {
            try
            {
                var request = new RestRequest("api/Employees", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };
                request.AddJsonBody(emp);
                var response = await _restClient.ExecuteAsync<Employee>(request);
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    throw new Exception($"Error: gagal menambah data - {response.ErrorMessage}");
                return response.Data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
