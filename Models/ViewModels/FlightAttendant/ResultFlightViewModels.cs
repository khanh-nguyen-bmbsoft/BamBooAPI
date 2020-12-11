using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BambooAirewayBE.API.Models.ViewModels.FlightAttendant
{
    public class ResultFlightViewModels
    {
        public int Id { get; set; }
        public LookupModels StaffId { get; set; }
        public string IdentifyName { get; set; }
        public string FullName { get; set; }
        public string PositonName { get; set; }
        public string Result { get; set; }
        public double Avarage { get; set; }
        public string Note { get; set; }
        public LookupModels Creator { get; set; }
    }
    public class ResultFlightRequestViewModels
    {
        public LookupModels StaffId { get; set; }
        public string IdentifyName { get; set; }
        public string FullName { get; set; }
        public string PositonName { get; set; }
        public string Result { get; set; }
        public double Avarage { get; set; }
        public string Note { get; set; }
        public LookupModels Creator { get; set; }
    }
}