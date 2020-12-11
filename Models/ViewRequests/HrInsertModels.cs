using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirewayBE.API.Models.ViewModels;

namespace BambooAirewayBE.API.Models.ViewRequests
{
    public class HrInsertModels
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; } //Title
        public string FullName { get; set; }
        public string CompanyEmail { get; set; }
        public string NickName { get; set; }
        public string PersonalPhone { get; set; }
        public string PersonalEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string[] Relationship { get; set; }
        public string PermanetAddress { get; set; }
        public string TemporaryAddress { get; set; }
        public string Group { get; set; }
        public string Department { get; set; }
        public string WorkingAddress { get; set; }
        public string Role { get; set; }
        public DateTime StartingDate { get; set; }
        public string[] Status { get; set; }
        public string WorkingPhone { get; set; }
        public string Level { get; set; }
        public string LineManager { get; set; }
        public DateTime LatestChangeDate { get; set; }
        public string ChangedModified { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public string CompanyAssets { get; set; }
        public string LeavingReason { get; set; }
        public int? LeavingAllowedNumber { get; set; }
        public int? TicketsNumberIssued { get; set; }
        public string Taxno { get; set; }
        public string SocialInsurantNumber { get; set; }
    }
    public class HrUpdateRequestModels
    {
        public string Email { get; set; }
        public HrViewModels HrModels { get; set; }
    }
}