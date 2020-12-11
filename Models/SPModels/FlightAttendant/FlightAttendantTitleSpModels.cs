using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirwayBE.API.Data;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Models.SPModels.FlightAttendant
{
    public class FlightAttendantTitleSpModels : BaseItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public DateTime? EffectiveDate { get; set; }

        public FlightAttendantTitleSpModels(SPRespository respository, ListItem item) : base(respository, item)
        {
            if (item == null) return;
            Id = item.Id;
            Title = item.FieldValues[FlightAttendantTitleField.InternalName.Title]?.ToString();
            EmployeeCode = item.FieldValues[FlightAttendantTitleField.InternalName.EmployeeCode]?.ToString();
            EmployeeName = item.FieldValues[FlightAttendantTitleField.InternalName.EmployeeName]?.ToString();
            PositionCode = item.FieldValues[FlightAttendantTitleField.InternalName.PositionCode]?.ToString();
            PositionName = item.FieldValues[FlightAttendantTitleField.InternalName.PositionName]?.ToString();
            if (item.FieldValues[FlightAttendantTitleField.InternalName.EffectiveDate] != null)
                EffectiveDate = Convert.ToDateTime(item.FieldValues[FlightAttendantTitleField.InternalName.EffectiveDate]);
        }
        public override BaseItem SyncToSPItem()
        {
            if (_item == null) return this;
            _item[FlightAttendantTitleField.InternalName.Title] = EmployeeCode;
            _item[FlightAttendantTitleField.InternalName.EmployeeCode] = EmployeeCode;
            _item[FlightAttendantTitleField.InternalName.EmployeeName] = EmployeeName;
            _item[FlightAttendantTitleField.InternalName.PositionCode] = PositionCode;
            _item[FlightAttendantTitleField.InternalName.PositionName] = PositionName;
            _item[FlightAttendantTitleField.InternalName.EffectiveDate] = EffectiveDate;
            return this;
        }
        public class FlightAttendantTitleField
        {
            public static class InternalName
            {
                public const string Title = "Title";
                public const string EmployeeCode = "EmployeeCode";
                public const string EmployeeName = "EmployeeName";
                public const string PositionCode = "PositionCode";
                public const string PositionName = "PositionName";
                public const string EffectiveDate = "EffectiveDate";


            }
        }
    }
}