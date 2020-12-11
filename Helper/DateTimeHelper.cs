using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirewayBE.API.Utilities.Constants;

namespace BambooAirewayBE.API.Helper
{
    public class DateTimeHelper
    {
        public static DateTime ConvertToLocalDatetime(DateTime input)
        {
            var vnZone = TimeZoneInfo.FindSystemTimeZoneById(Message.TimeZone.TimeCodeVn);
            return TimeZoneInfo.ConvertTime(input, vnZone);
           
        }

        public static DateTime ConvertToEnlishTime(DateTime input)
        {
            var britishZone = TimeZoneInfo.FindSystemTimeZoneById(Message.TimeZone.TimeCodeEngland);
            return TimeZoneInfo.ConvertTime(input, britishZone);
        }
    }
}