using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLTN_Admin.Web.ViewModels
{
    public class ManagementViewModel
    {
        public string Id { get; set; }
        
        public string Agent { get; set; }

        public string AgentId { get; set; }

        public string AgentName { get; set; }

        public string AgentCancelFee { get; set; }

        public string Admin { get; set; }

        public string AdminId { get; set; }
        
        public string AdminUserName { get; set; }
        
        public string AdminPassword { get; set; }
        
        public string AdminEmail { get; set; }
        
        public int AdminType { get; set; }

        public string IsCreator { get; set; }
        
        public bool Isroot { get; set; }
    }
}
