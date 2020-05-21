using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLTN_Admin.Web.ViewModels
{
    public class AgentForAdminViewModel : AgentViewModel
    {
        public bool AsRoot { get; set; } = false;
    }
}
