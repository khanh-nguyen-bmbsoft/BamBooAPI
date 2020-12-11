using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BambooAirewayBE.API.Utilities.ListConstant
{
    public class ListSPs
    {
        public const string ListTimeKeeping = "{0}/Lists/Timekeeping";
        public const string ListWorkingTime= "{0}/Lists/WorkingTime";
        public const string ListHr= "{0}/Lists/Hr";
        public const string ListDepartment= "{0}/Lists/Department";
        public const string ListFlightSchedule= "{0}/Lists/FlightSchedules";
        public const string ListFlightMembers = "{0}/Lists/FlightMembers";
        public const string ListFlightPassengers = "{0}/Lists/FlightPassengers";
        public const string ListFlightCrews = "{0}/Lists/FlightCrews";
        public const string ListFlightAttendantProfile = "{0}/Lists/FlightAttendantProfile";
        public const string ListFlightAttendantTitle = "{0}/Lists/FlightAttendantTitle";
        public const string ListReviewCategory = "{0}/Lists/ReviewCategory";
        public const string ListTitleTemplate = "{0}/Lists/TitleTemplate";
        public const string ListResultDetailFlightAttendant = "{0}/Lists/ResultDetailFlightAttendant";
        public const string ListResultFlight = "{0}/Lists/ResultFlight";
        public const string FlightPassengerDetail = "{0}/Lists/FlightPassengerDetail";
    }

    public static class Query
    {
        public const string ParameterInsert = "Insert Items";
        public const string TimeKeepingInsert = "<View><Query><Where><Eq><FieldRef Name='Title'/>" +
                                            "<Value Type='Text'>{0}</Value></Eq></Where></Query></View>";
    }
}