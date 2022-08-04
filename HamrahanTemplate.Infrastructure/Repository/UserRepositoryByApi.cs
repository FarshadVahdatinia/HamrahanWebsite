using Contexts;
using Hamrahan.Models;
using HamrahanTemplate.Application.Pagination;
using HamrahanTemplate.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HamrahanTemplate.Infrastructure.Repository
{
    public class UserRepositoryByApi
    {
      
        private string apiUrl = "https://localhost:44396/api/Person";
        private HttpClient _client;
        public UserRepositoryByApi() 
        {
            _client = new HttpClient();
           
        }

     
    }
}
