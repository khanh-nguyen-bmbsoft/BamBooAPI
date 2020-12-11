using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BambooAirewayBE.API.Models.ViewModels.FlightViewModels
{
    public class FlightMemberViewModels
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? FlightId { get; set; }
        public LookupModels FlightScheduleId { get; set; }
        public DateTime? FlightCreatedAt { get; set; }
        public DateTime? FlightUpdatedAt { get; set; }
        public int? Pilot { get; set; }
        public int? Attendant { get; set; }
        public int? FlightNumber { get; set; }
        public DateTime? FlightDate { get; set; }
    }

    public class GetFlDateAndFlNumberMemberModels
    {
        public DateTime FlightDate { get; set; }
        public int FlightNumber { get; set; }
    }
    public class FlightMemberRequestViewModels
    {
        public int? FlightId { get; set; }
        public LookupModels FlightScheduleId { get; set; }
        public DateTime? FlightCreatedAt { get; set; }
        public DateTime? FlightUpdatedAt { get; set; }
        public int? Pilot { get; set; }
        public int? Attendant { get; set; }
        public int FlightNumber { get; set; }
        public DateTime? FlightDate { get; set; }
    }
}