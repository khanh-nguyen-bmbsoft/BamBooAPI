using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BambooAirewayBE.API.Models.ViewModels
{
    public class TimeKeepingViewModels
    {
        public string DeviceName { get; set; }
        public string UserId { get; set; }
        public DateTime TimeKeepingDateTime { get; set; }
        public DateTime CreateTimeAt { get; set; }
        public DateTime UpdatedTimeAt { get; set; }
        public string EmployeeEmail { get; set; }
    }
}