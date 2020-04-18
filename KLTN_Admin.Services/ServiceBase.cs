using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.Services
{
    public abstract class ServiceBase
    {
        protected RestClient _client;

        public ServiceBase()
        {
            _client = new RestClient("http://localhost:3000");
        }
    }
}
