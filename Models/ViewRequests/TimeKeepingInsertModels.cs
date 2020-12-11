using System;

namespace BambooAirewayBE.API.Models.ViewModels
{
    public class TimeKeepingInsertModels
    {
        public int id { get; set; }
        public string device_name { get; set; }
        public string user_id { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string user_email { get; set; }
    }
}