using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using BambooAirewayBE.API.Models.SPModels;
using BambooAirwayBE.API.Utilities.Constants;
using BambooAirwayBE.API.Data;
using Microsoft.SharePoint.Client;
using Newtonsoft.Json;

namespace BambooAirwayBE.API.Utilities.Utils
{
    public static class Utils
    {
        public const int ProbationTime = 3;
        #region SharePoint
        public static string BuildUrlList(ClientContext client, string formatList, Web parentWeb = null)
        {
            if (parentWeb == null)
            {
                var uri = new Uri(client.Url);
                return string.Format(formatList, uri.AbsolutePath);
            }
            return string.Format(formatList, parentWeb.ServerRelativeUrl);
        }
        public static TimeKeepingSPModels[] GetTimeKeeping(ClientContext clientContext)
        {
            var timeKeepingRes = new SPRespository(clientContext, BuildUrlList(clientContext, BambooAirewayBE.API.Utilities.Constants.Constants.ListSPJob.TimeKeepingUrl));
            return timeKeepingRes.GetAll<TimeKeepingSPModels>((item) => new TimeKeepingSPModels(timeKeepingRes, item)).ToArray();
        }
        public static DepartmentSPModels[] GetDepartment(ClientContext clientContext)
        {
            var departmentRes = new SPRespository(clientContext, BuildUrlList(clientContext, BambooAirewayBE.API.Utilities.Constants.Constants.ListSPJob.DepartmentUrl));
            return departmentRes.GetAll((item) => new DepartmentSPModels(departmentRes, item)).ToArray();
        }
        public static WorkingTimeSpModels[] GetWorkingTime(ClientContext clientContext)
        {
            var workingTimeRes = new SPRespository(clientContext, BuildUrlList(clientContext, BambooAirewayBE.API.Utilities.Constants.Constants.ListSPJob.WorkingTimeUrl));
            return workingTimeRes.GetAll((item) => new WorkingTimeSpModels(workingTimeRes, item)).ToArray();
        }
        public static HrSpModels[] GetHr(ClientContext clientContext)
        {
            var itemRes = new SPRespository(clientContext, BuildUrlList(clientContext, BambooAirewayBE.API.Utilities.Constants.Constants.ListSPJob.HrUrl));
            return itemRes.GetAll((item) => new HrSpModels(itemRes, item)).ToArray();
        }
        public static ClientContext InitializeClientContext()
        {
            string userName = Settings.SPAccount; //give your username here  
            string password = Settings.SPPass; //give your password  
            string siteUrl = Settings.SPSite;
            var securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }

            var clientContext = new ClientContext(siteUrl)
            {
                Credentials = new SharePointOnlineCredentials(userName, securePassword)
            };
            return clientContext;
        }

        public static MemoryStream ConvertToMemoryStream(this Stream fileStream)
        {
            MemoryStream memStream = new MemoryStream();
            fileStream.CopyTo(memStream);
            return memStream;
        }

        public static string GetTemporaryDirectory()
        {
            string tempDirectory = Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString());

            if (!Directory.Exists(tempDirectory))
            {
                Directory.CreateDirectory(tempDirectory);
            }
            return tempDirectory;
        }

        public static int ToInt32(string s, int def = 0)
        {
            int result;
            return Int32.TryParse(s, out result) ? result : def;
        }

        public static bool ToBoolean(string s, bool def = false)
        {
            bool result;
            return Boolean.TryParse(s, out result) ? result : def;
        }


        #endregion

        #region CSV
        #region Empty Arrays

        public static readonly byte[] EmptyData = new byte[] { };
        public static readonly long[] EmptyIds = new long[] { };
        public static readonly object[] EMPTY_PARAMS = new object[] { };
        public static readonly string[] EMPTY_STRINGS = new string[] { };
        public static readonly char[] NEWLINES = new char[] { '\n', '\r' };
        public static readonly string[] NEWLINES_ENV = new string[] { Environment.NewLine };
        public static readonly char[] SLASHES = new char[] { '\\', '/' };
        public static readonly char[] SLASHES_FORWARD = new char[] { '/' };
        public static readonly char[] COMMAS = new char[] { ',' };
        public static readonly char[] SEMICOLONS = new char[] { ';' };
        public static readonly char[] COLONS = new char[] { ':' };
        public static readonly char[] DOTS = new char[] { '.' };
        public static readonly char[] CROSS = new char[] { '-' };
        public static readonly char[] SPACES = new char[] { ' ' };
        public static readonly char[] BLANKS = new char[] { ' ', '\t', '\n', '\r' };
        public static readonly string[] COMMA_SPLITS = new string[] { ", " };
        public static readonly HashSet<string> EmptyHash = new HashSet<string>();
        public static readonly DateTime MinDate = new DateTime(2000, 1, 1);

        #endregion



        public static int GenerateKid(HashSet<int> kids)
        {
            while (true)
            {
                var nextkid = GenerateRandom(121314, 967453);
                if (!kids.Contains(nextkid) && kids.Add(nextkid))
                    return nextkid;
            }
        }

        public static readonly RNGCryptoServiceProvider RandomGenerator = new RNGCryptoServiceProvider();

        public static int GenerateRandom(int minimumValue, int maximumValue)
        {
            var randomNumber = new byte[8];

            RandomGenerator.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = BitConverter.ToDouble(randomNumber, 0);

            // We are using Math.Max, and substracting 0.00000000001, 
            // to ensure "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / double.MaxValue) - 0.00000000001d);

            // We need to add one to the range, to allow for the rounding done with Math.Floor
            int range = maximumValue - minimumValue + 1;

            double randomValueInRange = Math.Floor(multiplier * range);

            return (int)(minimumValue + randomValueInRange);
        }

        public static IEnumerable<T> Yield<T>() { yield break; }
        public static IEnumerable<T> Yield<T>(T t) { yield return t; }
        public static IEnumerable<T> Yield<T>(T t, T t1) { yield return t; yield return t1; }
        public static IEnumerable<T> Yield<T>(T t, T t1, T t2) { yield return t; yield return t1; yield return t2; }
        public static IEnumerable<T> Yield<T>(T t, T t1, T t2, T t3) { yield return t; yield return t1; yield return t2; yield return t3; }
        public static IEnumerable<T> Yield<T>(T t, T t1, T t2, T t3, T t4) { yield return t; yield return t1; yield return t2; yield return t3; yield return t4; }
        public static IEnumerable<T> Yield<T>(T t, T t1, T t2, T t3, T t4, T t5) { yield return t; yield return t1; yield return t2; yield return t3; yield return t4; yield return t5; }
        public static IEnumerable<T> Yield<T>(T t, T t1, T t2, T t3, T t4, T t5, T t6) { yield return t; yield return t1; yield return t2; yield return t3; yield return t4; yield return t5; yield return t6; }
        public static IEnumerable<T> Yield<T>(T t, T t1, T t2, T t3, T t4, T t5, T t6, T t7) { yield return t; yield return t1; yield return t2; yield return t3; yield return t4; yield return t5; yield return t6; yield return t7; }

        public static string TypeToString(Type type)
        {
            StringBuilder retType = new StringBuilder();

            if (type.IsGenericType)
            {
                string[] parentType = type.FullName.Split('`');
                // We will build the type here.
                Type[] arguments = type.GetGenericArguments();

                StringBuilder argList = new StringBuilder();
                foreach (Type t in arguments)
                {
                    // Let's make sure we get the argument list.
                    string arg = TypeToString(t);
                    if (argList.Length > 0)
                    {
                        argList.AppendFormat(", {0}", arg);
                    }
                    else
                    {
                        argList.Append(arg);
                    }
                }

                if (argList.Length > 0)
                {
                    retType.AppendFormat("{0}<{1}>", parentType[0], argList.ToString());
                }
            }
            else
            {
                return type.ToString();
            }

            return retType.ToString();
        }


        public static string GenerateQuarterName(DateTime date)
        {
            return String.Format("Q{0} {1}", (date.Month + 2) / 3, date.Year);
        }

        public static string GenerateMonthName(DateTime date)
        {
            return string.Format("{0} {1}", date.ToString("MMM"), date.Year);
        }

        public static string GetCurrentDomain()
        {
            try
            {
                var prop = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties();
                if (prop != null)
                    return prop.DomainName;
            }
            catch { }
            return Environment.UserDomainName;
        }

        public static IEnumerable<Type> FindDerivedTypes(Type type)
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes().Where(t => type.IsAssignableFrom(t)));
        }
        public static T TryParseJson<T>(this string json) where T : new()
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return default(T);
            }
        }
        #endregion



        #region log
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }
        #endregion

        public static void LogSql(string logMessage, TextWriter w)
        {
            w.WriteLine("{0}", logMessage);
        }
        public static void LogSqLinLine(string logMessage, TextWriter w)
        {
            w.Write("{0}", logMessage);
        }
        public static int CalculateDayDifferenceBetweenTwoDates(DateTime startTime, DateTime endTime)
        {
            return (endTime - startTime).Days;
        }
        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            var monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }

        public static string BuildProbationTime(DateTime startTime)
        {
            var endTime = startTime.AddMonths(ProbationTime);
            return $"({startTime:dd'/'MM'/'yyyy} - {endTime:dd'/'MM'/'yyyy})";
        }
    }
}