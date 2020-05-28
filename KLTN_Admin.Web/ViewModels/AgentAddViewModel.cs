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

        public string MapTypeXeThuong { get; set; }

        public int MapWidthXeThuong { get; set; }

        public int MapHeightXeThuong { get; set; }

        public string OrderTypeXeThuong { get; set; }

        public string MapTypeXeGiuong { get; set; }

        public int MapWidthXeGiuong { get; set; }

        public int MapHeightXeGiuong { get; set; }

        public string OrderTypeXeGiuong { get; set; }

        public string MapAgent { get; set; }
    }
}
