using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BambooAirwayBE.API.Utilities.Utils
{
    public static class Settings
    {
        public readonly static string SPAccount = !string.IsNullOrEmpty(ConfigurationManager.AppSettings["SPServiceAccount"]) ? ConfigurationManager.AppSettings["SPServiceAccount"].ToString() : string.Empty;
        public readonly static string SPPass = !string.IsNullOrEmpty(ConfigurationManager.AppSettings["SPServicePass"]) ? ConfigurationManager.AppSettings["SPServicePass"].ToString() : string.Empty;
        public readonly static string SPSite = !string.IsNullOrEmpty(ConfigurationManager.AppSettings["SPSite"]) ? ConfigurationManager.AppSettings["SPSite"].ToString() : string.Empty;
    }
}