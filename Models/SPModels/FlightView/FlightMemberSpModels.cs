using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirewayBE.API.Helper;
using BambooAirwayBE.API.Data;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Models.SPModels.FlightView
{
    public class FlightMemberSpModels : BaseItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? FlightId { get; set; }
        public FieldLookupValue FlightScheduleId { get; set; }
        public DateTime? FlightCreatedAt { get; set; }
        public DateTime? FlightUpdatedAt { get; set; }
        public int? Pilot { get; set; }
        public int? Attendant { get; set; }
        public int FlightNumber { get; set; }
        public DateTime FlightDate { get; set; }
        public FlightMemberSpModels(SPRespository respository, ListItem item) : base(respository, item)
        {
            if (item == null) return;
            Id = item.Id;
            Title = item.FieldValues[FlightMemberSpModelsField.InternalName.Title]?.ToString();

            FlightNumber = Convert.ToInt32(item.FieldValues[FlightMemberSpModelsField.InternalName.FlightNumber]);
            if (item.FieldValues[FlightMemberSpModelsField.InternalName.FlightScheduleId] != null)
                FlightScheduleId = item.FieldValues[FlightMemberSpModelsField.InternalName.FlightScheduleId] as FieldLookupValue;

            if (item.FieldValues[FlightMemberSpModelsField.InternalName.FlightCreatedAt] != null)
                FlightCreatedAt = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightMemberSpModelsField.InternalName.FlightCreatedAt]));

            if (item.FieldValues[FlightMemberSpModelsField.InternalName.FlightUpdatedAt] != null)
                FlightUpdatedAt = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightMemberSpModelsField.InternalName.FlightUpdatedAt]));

            if (item.FieldValues[FlightMemberSpModelsField.InternalName.Pilot] != null)
                Pilot = Convert.ToInt32(item.FieldValues[FlightMemberSpModelsField.InternalName.Pilot]);

            if (item.FieldValues[FlightMemberSpModelsField.InternalName.Attendant] != null)
                Attendant = Convert.ToInt32(item.FieldValues[FlightMemberSpModelsField.InternalName.Attendant]);
            FlightDate = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightMemberSpModelsField.InternalName.FlightDate]));

            if (item.FieldValues[FlightMemberSpModelsField.InternalName.FlightId] != null)
                FlightId = Convert.ToInt32(item.FieldValues[FlightMemberSpModelsField.InternalName.FlightId]);
        }
        public override BaseItem SyncToSPItem()
        {
            if (_item == null) return this;
            _item[FlightMemberSpModelsField.InternalName.Title] = FlightId;
            _item[FlightMemberSpModelsField.InternalName.FlightId] = FlightId;
            _item[FlightMemberSpModelsField.InternalName.FlightNumber] = FlightNumber;
            _item[FlightMemberSpModelsField.InternalName.FlightScheduleId] = FlightScheduleId;
            _item[FlightMemberSpModelsField.InternalName.FlightCreatedAt] = FlightCreatedAt;
            _item[FlightMemberSpModelsField.InternalName.FlightUpdatedAt] = FlightUpdatedAt;
            _item[FlightMemberSpModelsField.InternalName.Pilot] = Pilot;
            _item[FlightMemberSpModelsField.InternalName.Attendant] = Attendant;
            _item[FlightMemberSpModelsField.InternalName.FlightDate] = FlightDate;
            return this;
        }
        public class FlightMemberSpModelsField
        {
            public static class InternalName
            {
                public const string Title = "Title";
                public const string FlightId = "FlightId";
                public const string FlightScheduleId = "FlightScheduleId";
                public const string FlightCreatedAt = "FlightCreatedAt";
                public const string FlightUpdatedAt = "FlightUpdatedAt";
                public const string Pilot = "Pilot";
                public const string Attendant = "Attendant";
                public const string FlightNumber = "FlightNumber";
                public const string FlightDate = "FlightDate";
            }
        }
    }
}