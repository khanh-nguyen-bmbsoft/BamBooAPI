using BambooAirwayBE.API.Data;
using Microsoft.SharePoint.Client;
using System;

namespace BambooAirewayBE.API.Models.SPModels.FlightAttendant
{
    public class FlightAttendantProfileSpModels : BaseItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public FieldLookupValue FlightAttendantCode { get; set; }
        public DateTime? WorkingDate { get; set; }
        public string FlightCode { get; set; }
        public DateTime? FlightDate { get; set; }
        public DateTime? FlightTimeUTC { get; set; }
        public DateTime? FlightTimeLocal { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string DutyCode { get; set; }
        public int CrewId { get; set; }
        public string[] EmployeeMission { get; set; }

        public FlightAttendantProfileSpModels(SPRespository respository, ListItem item) : base(respository, item)
        {
            if (item == null) return;
            Id = item.Id;
            Title = item.FieldValues[FlightAttendantProfileField.InternalName.Title]?.ToString();
            FlightAttendantCode = item.FieldValues[FlightAttendantProfileField.InternalName.FlightAttendantCode] as FieldLookupValue;
            FlightCode = item.FieldValues[FlightAttendantProfileField.InternalName.FlightCode]?.ToString();
            Departure = item.FieldValues[FlightAttendantProfileField.InternalName.Departure]?.ToString();
            Destination = item.FieldValues[FlightAttendantProfileField.InternalName.Destination]?.ToString();
            DutyCode = item.FieldValues[FlightAttendantProfileField.InternalName.DutyCode]?.ToString();
            CrewId = Convert.ToInt32(item.FieldValues[FlightAttendantProfileField.InternalName.CrewId]);

            if (item.FieldValues[FlightAttendantProfileField.InternalName.WorkingDate] != null)
                WorkingDate = Convert.ToDateTime(item.FieldValues[FlightAttendantProfileField.InternalName.WorkingDate]);

            if (item.FieldValues[FlightAttendantProfileField.InternalName.FlightDate] != null)
                FlightDate = Convert.ToDateTime(item.FieldValues[FlightAttendantProfileField.InternalName.FlightDate]);

            if (item.FieldValues[FlightAttendantProfileField.InternalName.FlightTimeUTC] != null)
                FlightTimeUTC = Convert.ToDateTime(item.FieldValues[FlightAttendantProfileField.InternalName.FlightTimeUTC]);

            if (item.FieldValues[FlightAttendantProfileField.InternalName.FlightTimeLocal] != null)
                FlightTimeLocal = Convert.ToDateTime(item.FieldValues[FlightAttendantProfileField.InternalName.FlightTimeLocal]);

            if (item.FieldValues[FlightAttendantProfileField.InternalName.EmployeeMission] != null)
                EmployeeMission = item.FieldValues[FlightAttendantProfileField.InternalName.EmployeeMission] as string[];
        }

        public override BaseItem SyncToSPItem()
        {
            if (_item == null) return this;
            _item[FlightAttendantProfileField.InternalName.Title] = FlightAttendantCode;
            _item[FlightAttendantProfileField.InternalName.WorkingDate] = WorkingDate;
            _item[FlightAttendantProfileField.InternalName.FlightCode] = FlightCode;
            _item[FlightAttendantProfileField.InternalName.FlightDate] = FlightDate;
            _item[FlightAttendantProfileField.InternalName.FlightTimeUTC] = FlightTimeUTC;
            _item[FlightAttendantProfileField.InternalName.FlightTimeLocal] = FlightTimeLocal;
            _item[FlightAttendantProfileField.InternalName.Departure] = Departure;
            _item[FlightAttendantProfileField.InternalName.Destination] = Destination;
            _item[FlightAttendantProfileField.InternalName.DutyCode] = DutyCode;
            _item[FlightAttendantProfileField.InternalName.CrewId] = CrewId;
            _item[FlightAttendantProfileField.InternalName.EmployeeMission] = EmployeeMission;
            return this;
        }

        public class FlightAttendantProfileField
        {
            public static class InternalName
            {
                public const string Title = "Title";
                public const string FlightAttendantCode = "FlightAttendantCode";
                public const string WorkingDate = "WorkingDate";
                public const string FlightCode = "FlightCode";
                public const string FlightDate = "FlightDate";
                public const string FlightTimeUTC = "FlightTimeUTC";
                public const string FlightTimeLocal = "FlightTimeLocal";
                public const string Departure = "Departure";
                public const string Destination = "Destination";
                public const string DutyCode = "DutyCode";
                public const string CrewId = "CrewId";
                public const string EmployeeMission = "EmployeeMission";
            }
        }
    }
}
