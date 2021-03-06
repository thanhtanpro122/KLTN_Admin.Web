﻿using KLTN_Admin.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.ServiceInterfaces
{
    public interface IAdminService
    {
        List<AdminSharedModel> GetAllAdmins(string adminId);

        AdminSharedModel GetAdminById(string adminId);

        AdminSharedModel CreateAdmin(AdminSharedModel admin);

        bool EditAdmin(AdminSharedModel admin);

        bool CheckUserName(string username);

        bool DeleteAdmin(string adminId);

        string[] Signin(string username, string password);

        List<ManagementSharedModel> GetAllManagement();

        bool CreateManagement(ManagementSharedModel management);

        List<ManagementSharedModel> GetManagementByAgentId(string agentId);

        List<ManagementSharedModel> GetManagementByAdminId(string adminId);

        bool ChangePassword(string adminId, string passold, string passnew);

        List<StatisticalSharedModel> Statistical(string agentId, DateTime fromdate, DateTime todate);
    }
}
