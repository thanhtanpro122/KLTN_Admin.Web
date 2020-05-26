using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLTN_Admin.Web.ViewModels
{
    public class AgentAddViewModel : AgentViewModel
    {
        public string PhoneFrom { get; set; }

        public string LocationFrom { get; set; }

        public string PhoneTo { get; set; }

        public string LocationTo { get; set; }

        public string MapType { get; set; }

        public int MapWidth { get; set; }

        public int MapHeight { get; set; }

        public string OrderType { get; set; }

        public string MapAgent { get; set; }
    }
}
