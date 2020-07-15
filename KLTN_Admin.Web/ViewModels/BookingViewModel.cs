using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KLTN_Admin.Web.ViewModels
{
    public class BookingViewModel
    {
        public string Id { get; set; }

        public string RouteDeparture { get; set; }

        public string SeatNumber { get; set; }
        
        public ConstViewModel SeatStatus { get; set; }
        
        public double Price { get; set; }
        
        public DateTime BookingTime { get; set; }
        
        public DateTime BookingExpiredTime { get; set; }
        
        public ConstViewModel Status { get; set; }
        
        public string BookingCode { get; set; }

        public string BookingInformationName { get; set; }

        public string BookingInformationPhoneNumber { get; set; }

        public string BookingInformationEmail { get; set; }

        public string BookingInformationIdentityId { get; set; }

        public string UserId { get; set; }
    }
}
