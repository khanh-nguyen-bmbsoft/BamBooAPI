using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BambooAirewayBE.API.Models.ViewModels.FlightAttendant
{
    public class TitleTemplateViewModels
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
    }

    public class TitleTemplateRequestViewModels
    {
        public string Title { get; set; }
        public string Code { get; set; }
    }
}