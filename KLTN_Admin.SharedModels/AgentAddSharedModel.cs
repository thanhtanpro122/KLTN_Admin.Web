using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.SharedModels
{
    public class AgentAddSharedModel : AgentSharedModel
    {
        public string PhoneFrom { get; set; }

        public string LocationFrom { get; set; }

        public double LatitudeLocationFrom { get; set; }

        public double LongitudeLocationFrom { get; set; }

        public string PhoneTo { get; set; }

        public string LocationTo { get; set; }

        public double LatitudeLocationTo { get; set; }

        public double LongitudeLocationTo { get; set; }

        public string MapTypeXeThuong { get; set; }

        public int MapWidthXeThuong { get; set; }

        public int MapHeightXeThuong { get; set; }

        public string OrderTypeXeThuong { get; set; }

        public string MapTypeXeGiuong { get; set; }

        public int MapWidthXeGiuong { get; set; }

        public int MapHeightXeGiuong { get; set; }

        public string OrderTypeXeGiuong { get; set; }
    }
}
