using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BambooAirewayBE.API.Models.ViewModels.FlightAttendant
{
    public class FlightAttendantTitleViewModels
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public DateTime? EffectiveDate { get; set; }
    }

    public class FlightAttendantTitleRequestViewModels
    {
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public DateTime? EffectiveDate { get; set; }
    }
}