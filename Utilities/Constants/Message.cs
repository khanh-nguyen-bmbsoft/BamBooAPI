using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BambooAirewayBE.API.Utilities.Constants
{
    public class Message
    {
        public static class MessageApi
        {
            public const string Success = "Insert Success!";
            public const string NoItem = "No Item!";
            public const string MissingItem = "Cannot find item";
            
        }

        public static class TimeZone
        {
            public const string TimeCodeEngland = "GMT Standard Time";
            public const string TimeCodeVn = "SE Asia Standard Time";
        }
    }
}