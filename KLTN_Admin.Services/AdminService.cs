using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using KLTN_Admin.ServiceInterfaces;
using KLTN_Admin.SharedModels;
using RestSharp;
using Newtonsoft.Json;

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

        public AdminSharedModel GetAdminById(int adminId)
        {
            var request = new RestRequest("/admin/{admin_id}", Method.GET);
            request.AddUrlSegment("admin_id", adminId);
            var response = _client.Execute(request);
            var statusCode = response.StatusCode;
            if((int)statusCode != 200)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<AdminSharedModel>(response.Content);
        }
        public bool CreateAdmin(AdminSharedModel admin)
        {
            var request = new RestRequest("/addadmin", Method.POST, DataFormat.Json);
            request.AddJsonBody(admin);
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return false;
            }
            return true;
        }

        public bool EditAdmin(AdminSharedModel admin)
        {
            var request = new RestRequest("/admin/{admin_id}", Method.PATCH);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(admin);
            request.AddUrlSegment("admin_id", admin.Id);
            var response = _client.Execute(request);
            var statusCode = response.StatusCode;
            if ((int)statusCode != 200)
            {
                return false;
            }
            return true;
        }

        public bool CheckUserName(string username)
        {
            var request = new RestRequest("/admin/CheckUserName", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { UserName = username });
            var response = _client.Execute(request);
            var statusCode = response.StatusCode;
            if ((int)statusCode == 200)
            {
                return true;
            }
            return false;
        }
    }
}
