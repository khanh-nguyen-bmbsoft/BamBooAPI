using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BambooAirewayBE.API.Models.ViewModels.FlightAttendant
{
    public class FlightAttendantProfileViewModels
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FlightAttendantCode { get; set; }
        public DateTime? WorkingDate { get; set; }
        public string FlightCode { get; set; }
        public DateTime? FlightDate { get; set; }
        public DateTime? FlightTimeUTC { get; set; }
        public DateTime? FlightTimeLocal { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string DutyCode { get; set; }
        public int CrewId { get; set; }
        public string[] EmployeeMission { get; set; }
    }

    public class FlightAttendantProfileRequestViewModels
    {
        public int FlightAttendantCodeId { get; set; }
        public DateTime? WorkingDate { get; set; }
        public string FlightCode { get; set; }
        public DateTime? FlightDate { get; set; }
        public DateTime? FlightTimeUTC { get; set; }
        public DateTime? FlightTimeLocal { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string DutyCode { get; set; }
        public int CrewId { get; set; }
        public string[] EmployeeMission { get; set; }
    }
}