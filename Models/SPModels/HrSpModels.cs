using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirwayBE.API.Data;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Models.SPModels
{
    public class HrSpModels : BaseItem
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; } //Title
        public string Image { get; set; }
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
        public double? LeavingAllowedNumber { get; set; }
        public double? TicketsNumberIssued { get; set; }
        public string Taxno { get; set; }
        public string SocialInsurantNumber { get; set; }
        public HrSpModels(SPRespository respository, ListItem item) : base(respository, item)
        {
            if (item == null) return;
            Id = item.Id;
            EmployeeCode = item.FieldValues[HrSpModelsField.InternalName.EmployeeCode]?.ToString();
            FullName = item.FieldValues[HrSpModelsField.InternalName.FullName]?.ToString();
            CompanyEmail = item.FieldValues[HrSpModelsField.InternalName.CompanyEmail]?.ToString();
            NickName = item.FieldValues[HrSpModelsField.InternalName.NickName]?.ToString();
            PersonalPhone = item.FieldValues[HrSpModelsField.InternalName.PersonalPhone]?.ToString();
            PersonalEmail = item.FieldValues[HrSpModelsField.InternalName.PersonalEmail]?.ToString();
            DateOfBirth = Convert.ToDateTime(item.FieldValues[HrSpModelsField.InternalName.DateOfBirth]);
            Relationship = item.FieldValues[HrSpModelsField.InternalName.Relationship] as string[];
            PermanetAddress = item.FieldValues[HrSpModelsField.InternalName.PermanetAddress]?.ToString();
            TemporaryAddress = item.FieldValues[HrSpModelsField.InternalName.TemporaryAddress]?.ToString();
            Group = item.FieldValues[HrSpModelsField.InternalName.Group]?.ToString();
            Department = item.FieldValues[HrSpModelsField.InternalName.Department]?.ToString();
            WorkingAddress = item.FieldValues[HrSpModelsField.InternalName.WorkingAddress]?.ToString();
            Role = item.FieldValues[HrSpModelsField.InternalName.Role]?.ToString();
            StartingDate = Convert.ToDateTime(item.FieldValues[HrSpModelsField.InternalName.StartingDate]);
            Status = item.FieldValues[HrSpModelsField.InternalName.Status] as string[];
            WorkingPhone = item.FieldValues[HrSpModelsField.InternalName.WorkingPhone]?.ToString();
            Level = item.FieldValues[HrSpModelsField.InternalName.Level]?.ToString();
            LineManager = item.FieldValues[HrSpModelsField.InternalName.LineManager]?.ToString();
            LatestChangeDate = Convert.ToDateTime(item.FieldValues[HrSpModelsField.InternalName.LatestChangeDate]);
            ChangedModified = item.FieldValues[HrSpModelsField.InternalName.ChangedModified]?.ToString();
            ExpiredDate = Convert.ToDateTime(item.FieldValues[HrSpModelsField.InternalName.ExpiredDate]);
            Experience = item.FieldValues[HrSpModelsField.InternalName.Experience]?.ToString();
            Education = item.FieldValues[HrSpModelsField.InternalName.Education]?.ToString();
            CompanyAssets = item.FieldValues[HrSpModelsField.InternalName.CompanyAssets]?.ToString();
            LeavingReason = item.FieldValues[HrSpModelsField.InternalName.LeavingReason]?.ToString();
            Taxno = item.FieldValues[HrSpModelsField.InternalName.Taxno]?.ToString();
            SocialInsurantNumber = item.FieldValues[HrSpModelsField.InternalName.SocialInsurantNumber]?.ToString();
            if (item[HrSpModelsField.InternalName.Image] != null)
                Image = item[HrSpModelsField.InternalName.Image]?.ToString();
            if (item[HrSpModelsField.InternalName.LeavingAllowedNumber] != null)
                LeavingAllowedNumber = Convert.ToInt32(item[HrSpModelsField.InternalName.LeavingAllowedNumber]);
            if (item[HrSpModelsField.InternalName.TicketsNumberIssued] != null)
                TicketsNumberIssued = Convert.ToInt32(item[HrSpModelsField.InternalName.TicketsNumberIssued]);
        }
        
        public override BaseItem SyncToSPItem()
        {
            if (_item == null) return this;
            _item[HrSpModelsField.InternalName.EmployeeCode] = EmployeeCode;
            _item[HrSpModelsField.InternalName.FullName] = FullName;
            _item[HrSpModelsField.InternalName.CompanyEmail] = CompanyEmail;
            _item[HrSpModelsField.InternalName.NickName] = NickName;
            _item[HrSpModelsField.InternalName.PersonalPhone] = PersonalPhone;
            _item[HrSpModelsField.InternalName.PersonalEmail] = PersonalEmail;
            _item[HrSpModelsField.InternalName.DateOfBirth] = DateOfBirth;
            _item[HrSpModelsField.InternalName.Relationship]= Relationship;
            _item[HrSpModelsField.InternalName.PermanetAddress] = PermanetAddress;
            _item[HrSpModelsField.InternalName.TemporaryAddress] = TemporaryAddress;
            _item[HrSpModelsField.InternalName.Group] = Group;
            _item[HrSpModelsField.InternalName.Department] = Department;
            _item[HrSpModelsField.InternalName.WorkingAddress] = WorkingAddress;
            _item[HrSpModelsField.InternalName.Role] = Role;
            _item[HrSpModelsField.InternalName.StartingDate] = StartingDate;
            _item[HrSpModelsField.InternalName.Status] = Status;
            _item[HrSpModelsField.InternalName.WorkingPhone] = WorkingPhone;
            _item[HrSpModelsField.InternalName.Level] = Level;
            _item[HrSpModelsField.InternalName.LineManager] = LineManager;
            _item[HrSpModelsField.InternalName.LatestChangeDate]= LatestChangeDate;
            _item[HrSpModelsField.InternalName.ChangedModified] = ChangedModified;
            _item[HrSpModelsField.InternalName.ExpiredDate] = ExpiredDate;
            _item[HrSpModelsField.InternalName.Experience] = Experience;
            _item[HrSpModelsField.InternalName.Education] = Education;
            _item[HrSpModelsField.InternalName.CompanyAssets] = CompanyAssets;
            _item[HrSpModelsField.InternalName.LeavingReason] = LeavingReason;
            _item[HrSpModelsField.InternalName.Taxno] = Taxno;
            _item[HrSpModelsField.InternalName.SocialInsurantNumber] = SocialInsurantNumber;
            _item[HrSpModelsField.InternalName.Image] = Image;
            _item[HrSpModelsField.InternalName.LeavingAllowedNumber] = LeavingAllowedNumber;
            _item[HrSpModelsField.InternalName.TicketsNumberIssued] = TicketsNumberIssued;
            return this;
        }

        public class HrSpModelsField
        {
            public static class InternalName
            {
                public const string Image = "Image";
                public const string EmployeeCode = "Title";
                public const string DateOfBirth = "DateOfBirth";
                public const string StartingDate = "StartingDate";
                public const string LatestChangeDate = "LatestChangeDate";
                public const string ExpiredDate = "ExpiredDate";
                public const string FullName = "FullName";
                public const string CompanyEmail = "CompanyEmail";
                public const string NickName = "NickName";
                public const string PersonalPhone = "PersonalPhone";
                public const string PersonalEmail = "PersonalEmail";
                public const string Relationship = "Relationship";
                public const string PermanetAddress = "PermanetAddress";
                public const string TemporaryAddress = "TemporaryAddress";
                public const string Group = "Group";
                public const string Department = "Department";
                public const string WorkingAddress = "WorkingAddress";
                public const string Role = "Role";
                public const string Status = "Status";
                public const string WorkingPhone = "WorkingPhone";
                public const string Level = "Level";
                public const string LineManager = "LineManager";
                public const string ChangedModified = "ChangedModified";
                public const string Experience = "Experience";
                public const string Education = "Education";
                public const string CompanyAssets = "CompanyAssets";
                public const string LeavingReason = "LeavingReason";
                public const string LeavingAllowedNumber = "LeavingAllowedNumber";
                public const string TicketsNumberIssued = "TicketsNumberIssued";
                public const string Taxno = "Taxno";
                public const string SocialInsurantNumber = "SocialInsurantNumber";
            }
        }
    }
}