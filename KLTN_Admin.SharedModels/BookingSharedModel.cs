using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KLTN_Admin.SharedModels
{
    public class BookingSharedModel
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("routeDeparture")]
        public string RouteDeparture { get; set; }

        [JsonProperty("seatNumber")]
        public string SeatNumber { get; set; }

        [JsonProperty("seatStatus")]
        public ConstSharedModel SeatStatus { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("bookingTime")]
        public DateTime BookingTime { get; set; }

        [JsonProperty("bookingExpiredTime")]
        public DateTime BookingExpiredTime { get; set; }

        [JsonProperty("status")]
        public ConstSharedModel Status { get; set; }

        [JsonProperty("bookingCode")]
        public string BookingCode { get; set; }

        [JsonProperty("bookingInformation")]
        public BookingInformation BookingInformation { get; set; }

        [JsonProperty("user")]
        public string UserId { get; set; }
    }

    public class BookingInformation
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phonenumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("identityId")]
        public string IdentityId { get; set; }
    }
}
