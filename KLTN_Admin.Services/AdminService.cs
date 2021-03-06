﻿using System;
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

        public List<AdminSharedModel> GetAllAdmins(string adminId)
        {
            var request = new RestRequest("/admin-by-agent/{admin_id}", Method.GET);
            request.AddUrlSegment("admin_id", adminId);
            return _client.Execute<List<AdminSharedModel>>(request).Data;
        }

        public AdminSharedModel GetAdminById(string adminId)
        {
            var request = new RestRequest("/admin/{admin_id}", Method.GET);
            request.AddUrlSegment("admin_id", adminId);
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<AdminSharedModel>(response.Content);
        }
        public AdminSharedModel CreateAdmin(AdminSharedModel admin)
        {
            var request = new RestRequest("/admin", Method.POST, DataFormat.Json);
            request.AddJsonBody(admin);
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<AdminSharedModel>(response.Content);
        }

        public bool EditAdmin(AdminSharedModel admin)
        {
            var request = new RestRequest("/admin/{admin_id}", Method.PATCH, DataFormat.Json);
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
            var request = new RestRequest("/admin/CheckUserName", Method.GET, DataFormat.Json);
            request.AddJsonBody(new { UserName = username });
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode == 200)
            {
                return true;
            }
            return false;
        }
        public bool DeleteAdmin(string adminId)
        {
            var request = new RestRequest("/admin/{admin_id}", Method.DELETE);
            request.AddUrlSegment("admin_id", adminId);
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return false;
            }
            return true;
        }

        public string[] Signin(string textusername, string textpassword)
        {
            var token = "";
            var adminid = "";
            var isRootAdmin = "";
            var request = new RestRequest("/admin/signin", Method.POST, DataFormat.Json);
            request.AddJsonBody(new { username = textusername, password = textpassword });
            var response = _client.Execute(request);
            var resJson = JsonConvert.DeserializeObject<dynamic>(response.Content);
            var statusCode = (int)response.StatusCode;
            if (statusCode == 200)
            {
                token = resJson.token;
                adminid = resJson.id;
                isRootAdmin = resJson.isRootAdmin.Value ? "1" : "0";
                var test = new string[]
                {
                    token,adminid,isRootAdmin
                };
                return test;
            }
            return null;
        }

        public bool CreateManagement(ManagementSharedModel management)
        {
            var request = new RestRequest("/managementadmin", Method.POST, DataFormat.Json);
            request.AddJsonBody(management);
            var response = _client.Execute(request);
            var statusCode = (int)response.StatusCode;
            if (statusCode != 200)
            {
                return false;
            }
            return true;
        }

        public List<ManagementSharedModel> GetManagementByAgentId(string agentId)
        {
            var request = new RestRequest("/management/managementlistbyAgent/{agent_id}", Method.GET, DataFormat.Json);
            request.AddUrlSegment("agent_id", agentId);
            //request.AddJsonBody(new{ admin = adminId });
            var response = _client.Execute(request);
            return JsonConvert.DeserializeObject<List<ManagementSharedModel>>(response.Content);
        }

        public List<ManagementSharedModel> GetManagementByAdminId(string adminId)
        {
            var request = new RestRequest("/management/managementlistbyAdmin/{admin_id}", Method.GET, DataFormat.Json);
            request.AddUrlSegment("admin_id", adminId);
            //request.AddJsonBody(new{ admin = adminId });
            var response = _client.Execute(request);
            return JsonConvert.DeserializeObject<List<ManagementSharedModel>>(response.Content);
        }

        public List<ManagementSharedModel> GetAllManagement()
        {
            var request = new RestRequest("/managementadmin", Method.GET);
            return _client.Execute<List<ManagementSharedModel>>(request).Data;
        }

        public bool ChangePassword(string adminId, string passold, string passnew)
        {
            var request = new RestRequest("/admin/changepassword", Method.POST, DataFormat.Json);
            request.AddJsonBody(new { adminId, passold, passnew});
            var response = _client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public List<StatisticalSharedModel> Statistical(string agentId, DateTime fromdate, DateTime todate)
        {
            var request = new RestRequest("/statistical", Method.POST, DataFormat.Json);
            request.AddJsonBody(new { agentId, fromdate, todate });
            var response = _client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var data = response.Content;
                if (!string.IsNullOrWhiteSpace(data))
                {
                    return JsonConvert.DeserializeObject<List<StatisticalSharedModel>>(data);
                }
            }
            return null;
        }
    }
}
