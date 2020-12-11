using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BambooAirewayBE.API.Models.ViewModels.FlightAttendant
{
    public class ResultDetailFlightAttendantViewModels
    {
        public int Id { get; set; }
        public LookupModels EmployeeCode { get; set; }
        public string Result { get; set; }
        public double? Avarage { get; set; }
        public string Note { get; set; }
        public int? Deadline { get; set; }
        public LookupModels Assessor { get; set; }
    }

    public class ResultDetailFlightAttendantRequestViewModels
    {
        public LookupModels EmployeeCode { get; set; }
        public string Result { get; set; }
        public double? Avarage { get; set; }
        public string Note { get; set; }
        public int? Deadline { get; set; }
        public LookupModels Assessor { get; set; }
    }
}