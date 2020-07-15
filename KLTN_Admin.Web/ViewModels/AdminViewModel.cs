using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLTN_Admin.Web.ViewModels
{
    public class AdminViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int AdminType { get; set; }

        public string[] AgentId { get; set; }

        public string[] IsRoot { get; set; } = new string[0];

        public string[] AgentName { get; set; }

        public string[] RootAgent { get; set; }

    }
}
