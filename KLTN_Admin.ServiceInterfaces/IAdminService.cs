using KLTN_Admin.SharedModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.ServiceInterfaces
{
    public interface IAdminService
    {
        List<AdminSharedModel> GetAllAdmins();
    }
}
