using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLTN_Admin.Web.ViewModels
{
    public class MapViewModel
    {
        public string Id { get; set; }

        public AgentViewModel Agent { get; set; }

        public ConstViewModel Type { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public ConstViewModel OrderType { get; set; }
    }
}
