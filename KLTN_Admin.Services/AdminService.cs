using System;
using System.Collections.Generic;
using System.Text;
using KLTN_Admin.ServiceInterfaces;
using KLTN_Admin.SharedModels;
using RestSharp;

namespace KLTN_Admin.Services
{
    public class AdminService : ServiceBase, IAdminService
    {
        public AdminService() : base()
        {
        }

        public List<AdminSharedModel> GetAllAdmins()
        {
            var request = new RestRequest("/admin", Method.GET);
            return _client.Execute<List<AdminSharedModel>>(request).Data;
        }
    }
}
