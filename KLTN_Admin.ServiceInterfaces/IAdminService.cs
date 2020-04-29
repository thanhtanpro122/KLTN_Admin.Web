using KLTN_Admin.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.ServiceInterfaces
{
    public interface IAdminService
    {
        List<AdminSharedModel> GetAllAdmins();

        AdminSharedModel GetAdminById(string adminId);

        bool CreateAdmin(AdminSharedModel admin);

        bool EditAdmin(AdminSharedModel admin);

        bool CheckUserName(string username);

        bool DeleteAdmin(string adminId);

    }
}
