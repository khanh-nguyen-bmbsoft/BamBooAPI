using BambooAirwayBE.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirewayBE.API.Helper;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Models.SPModels.FlightView
{
    public class FlightPassengerSpModels : BaseItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int FlightId { get; set; }
        public FieldLookupValue FlightScheduleId { get; set; }
        public DateTime? FlightCreatedAt { get; set; }
        public DateTime? FlightUpdatedAt { get; set; }
        public int? Economy { get; set; }
        public int? Business { get; set; }
        public string EconomySsrCode { get; set; }
        public string BusinessSsrCode { get; set; }
        public int? FlightNumber { get; set; }
        public DateTime? FlightDate { get; set; }
        public FlightPassengerSpModels(SPRespository respository, ListItem item) : base(respository, item)
        {
            if (item == null) return;
            Id = item.Id;
            Title = item.FieldValues[FlightPassengerSpModelsField.InternalName.Title]?.ToString();
            FlightId =Convert.ToInt32(item.FieldValues[FlightPassengerSpModelsField.InternalName.FlightId]) ;
            EconomySsrCode = item.FieldValues[FlightPassengerSpModelsField.InternalName.EconomySsrCode]?.ToString();
            BusinessSsrCode = item.FieldValues[FlightPassengerSpModelsField.InternalName.BusinessSsrCode]?.ToString();
            if (item.FieldValues[FlightPassengerSpModelsField.InternalName.FlightScheduleId] != null)
                FlightScheduleId = item.FieldValues[FlightPassengerSpModelsField.InternalName.FlightScheduleId] as FieldLookupValue;
            if (item.FieldValues[FlightPassengerSpModelsField.InternalName.FlightCreatedAt] != null)
                FlightCreatedAt = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightPassengerSpModelsField.InternalName.FlightCreatedAt]));
            if (item.FieldValues[FlightPassengerSpModelsField.InternalName.FlightUpdatedAt] != null)
                FlightUpdatedAt = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightPassengerSpModelsField.InternalName.FlightUpdatedAt]));
            if (item.FieldValues[FlightPassengerSpModelsField.InternalName.Economy] != null)
                Economy = Convert.ToInt32(item.FieldValues[FlightPassengerSpModelsField.InternalName.Economy]);
            if (item.FieldValues[FlightPassengerSpModelsField.InternalName.Business] != null)
                Business = Convert.ToInt32(item.FieldValues[FlightPassengerSpModelsField.InternalName.Business]);
            if (item.FieldValues[FlightPassengerSpModelsField.InternalName.FlightNumber] != null)
                FlightNumber = Convert.ToInt32(item.FieldValues[FlightPassengerSpModelsField.InternalName.FlightNumber]);
            if (item.FieldValues[FlightPassengerSpModelsField.InternalName.FlightDate] != null)
                FlightDate = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightPassengerSpModelsField.InternalName.FlightDate]));
        }
        public override BaseItem SyncToSPItem()
        {
            if (_item == null) return this;
            _item[FlightPassengerSpModelsField.InternalName.Title] = Title;
            _item[FlightPassengerSpModelsField.InternalName.FlightId] = FlightId;
            _item[FlightPassengerSpModelsField.InternalName.EconomySsrCode] = EconomySsrCode;
            _item[FlightPassengerSpModelsField.InternalName.BusinessSsrCode] = BusinessSsrCode;
            _item[FlightPassengerSpModelsField.InternalName.FlightScheduleId] = FlightScheduleId;
            _item[FlightPassengerSpModelsField.InternalName.FlightCreatedAt] = FlightCreatedAt;
            _item[FlightPassengerSpModelsField.InternalName.FlightUpdatedAt] = FlightUpdatedAt;
            _item[FlightPassengerSpModelsField.InternalName.Economy] = Economy;
            _item[FlightPassengerSpModelsField.InternalName.Business] = Business;
            _item[FlightPassengerSpModelsField.InternalName.FlightNumber] = FlightNumber;
            _item[FlightPassengerSpModelsField.InternalName.FlightDate] = FlightDate;
            return this;
        }
        public class FlightPassengerSpModelsField
        {
            public static class InternalName
            {
                public const string Title = "Title";
                public const string FlightId = "FlightId";
                public const string FlightScheduleId = "FlightScheduleId";
                public const string FlightCreatedAt = "FlightCreatedAt";
                public const string FlightUpdatedAt = "FlightUpdatedAt";
                public const string Economy = "Economy";
                public const string Business = "Business";
                public const string EconomySsrCode = "EconomySsrCode";
                public const string BusinessSsrCode = "BusinessSsrCode";
                public const string FlightNumber = "FlightNumber";
                public const string FlightDate = "FlightDate";
            }
        }
    }
}