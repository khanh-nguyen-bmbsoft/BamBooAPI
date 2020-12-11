using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BambooAirewayBE.API.Models.ViewModels.FlightViewModels
{
    public class FlightPassengerViewModels
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public LookupModels FlightScheduleId { get; set; }
        public DateTime? FlightCreatedAt { get; set; }
        public DateTime? FlightUpdatedAt { get; set; }
        public int? Economy { get; set; }
        public int? Business { get; set; }
        public string EconomySsrCode { get; set; }
        public string BusinessSsrCode { get; set; }
        public int? FlightNumber { get; set; }
        public DateTime? FlightDate { get; set; }
    }

    public class FlightPassengerGetflDateAndflNumber
    {
        public int FlightNumber { get; set; }
        public DateTime FlightDate { get; set; }
    }
    public class FlightPassengerRequestViewModels
    {
        public int FlightId { get; set; }
        public LookupModels FlightScheduleId { get; set; }
        public DateTime? FlightCreatedAt { get; set; }
        public DateTime? FlightUpdatedAt { get; set; }
        public int? Economy { get; set; }
        public int? Business { get; set; }
        public string EconomySsrCode { get; set; }
        public string BusinessSsrCode { get; set; }
        public int? FlightNumber { get; set; }
        public DateTime? FlightDate { get; set; }
    }
}