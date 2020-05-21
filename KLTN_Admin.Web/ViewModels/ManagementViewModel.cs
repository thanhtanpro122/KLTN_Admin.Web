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
        
        public string Admin { get; set; }
        
        public string IsCreator { get; set; }
        
        public bool Isroot { get; set; }
    }
}
