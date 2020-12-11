using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirewayBE.API.Helper;
using BambooAirwayBE.API.Data;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Models.SPModels.FlightView
{
    public class FlightScheduleSpModels : BaseItem
    {
        public int Id { get; set; }
        public string FlightId { get; set; }
        public DateTime? FlightCreatedAt { get; set; }
        public DateTime? FlightUpdatedAt { get; set; }
        public string AircraftId { get; set; }
        public DateTime? FlightDateGMT0 { get; set; }
        public DateTime? FlightDateGMT5 { get; set; }
        public DateTime? FlightDateGMT7 { get; set; }
        public DateTime? FlightDate { get; set; }
        public string FlightNumber { get; set; }
        public string Status { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? DepartureDateGMT0 { get; set; }
        public DateTime? DepartureDateGmt7 { get; set; }
        public string DepartureGate { get; set; }
        public string BoardingStatus { get; set; }
        public string BoardingTime { get; set; }
        public DateTime? FlightEtd { get; set; }
        public DateTime? FlightEtdGmt0 { get; set; }
        public DateTime? FlightEtdGmt7 { get; set; }
        public DateTime? FlightStd { get; set; }
        public DateTime? FlightStdGmt0 { get; set; }
        public DateTime? FlightStdGmt7 { get; set; }
        public DateTime? FlightEta { get; set; }
        public DateTime? FlightEtaGmt0 { get; set; }
        public DateTime? FlightEtaGmt7 { get; set; }
        public DateTime? FlightSta { get; set; }
        public DateTime? FlightStaGmt0 { get; set; }
        public DateTime? FlightStaGmt7 { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Route { get; set; }
        public string FlightReg { get; set; }
        public string FlightAcType { get; set; }
        public FlightScheduleSpModels(SPRespository respository, ListItem item) : base(respository, item)
        {
            if (item == null) return;
            Id = item.Id;
            FlightId = item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightId]?.ToString();
            AircraftId = item.FieldValues[FlightScheduleSpModelsField.InternalName.AircraftId]?.ToString();
            FlightNumber = item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightNumber]?.ToString();
            Status = item.FieldValues[FlightScheduleSpModelsField.InternalName.Status]?.ToString();
            DepartureGate = item.FieldValues[FlightScheduleSpModelsField.InternalName.DepartureGate]?.ToString();
            BoardingStatus = item.FieldValues[FlightScheduleSpModelsField.InternalName.BoardingStatus]?.ToString();
            BoardingTime = item.FieldValues[FlightScheduleSpModelsField.InternalName.BoardingTime]?.ToString();
            Origin = item.FieldValues[FlightScheduleSpModelsField.InternalName.Origin]?.ToString();
            Destination = item.FieldValues[FlightScheduleSpModelsField.InternalName.Destination]?.ToString();
            Route = item.FieldValues[FlightScheduleSpModelsField.InternalName.Route]?.ToString();
            FlightReg = item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightReg]?.ToString();
            FlightAcType = item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightAcType]?.ToString();
            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightCreatedAt] != null)
                FlightCreatedAt = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightCreatedAt]));
            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightUpdatedAt] != null)
                FlightUpdatedAt = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightUpdatedAt]));
            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightDateGMT0] != null)
                FlightDateGMT0 = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightDateGMT0]));

            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightDateGMT5] != null)
                FlightDateGMT5 = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightDateGMT5]));

            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightDateGMT7] != null)
                FlightDateGMT7 = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightDateGMT7]));

            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightDate] != null)
                FlightDate = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightDate]));

            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.DepartureDate] != null)
                DepartureDate = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.DepartureDate]));

            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.DepartureDateGMT0] != null)
                DepartureDateGMT0 = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.DepartureDateGMT0]));

            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.DepartureDateGmt7] != null)
                DepartureDateGmt7 = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.DepartureDateGmt7]));

            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightEtd] != null)
                FlightEtd = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightEtd]));

            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightEtdGmt0] != null)
                FlightEtdGmt0 = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightEtdGmt0]));

            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightEtdGmt7] != null)
                FlightEtdGmt7 = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightEtdGmt7]));

            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightStd] != null)
                FlightStd = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightStd]));

            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightStdGmt0] != null)
                FlightStdGmt0 = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightStdGmt0]));

            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightStdGmt7] != null)
                FlightStdGmt7 = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightStdGmt7]));

            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightEta] != null)
                FlightEta = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightEta]));

            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightEtaGmt0] != null)
                FlightEtaGmt0 = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightEtaGmt0]));

            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightEtaGmt7] != null)
                FlightEtaGmt7 = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightEtaGmt7]));

            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightSta] != null)
                FlightSta = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightSta]));

            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightStaGmt0] != null)
                FlightStaGmt0 = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightStaGmt0]));

            if (item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightStaGmt7] != null)
                FlightStaGmt7 = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightScheduleSpModelsField.InternalName.FlightStaGmt7]));
        }
        public override BaseItem SyncToSPItem()
        {
            if (_item == null) return this;
            _item[FlightScheduleSpModelsField.InternalName.FlightId] = FlightId;
            _item[FlightScheduleSpModelsField.InternalName.AircraftId] = AircraftId;
            _item[FlightScheduleSpModelsField.InternalName.FlightNumber] = FlightNumber;
            _item[FlightScheduleSpModelsField.InternalName.Status] = Status;
            _item[FlightScheduleSpModelsField.InternalName.DepartureGate] = DepartureGate;
            _item[FlightScheduleSpModelsField.InternalName.BoardingStatus] = BoardingStatus;
            _item[FlightScheduleSpModelsField.InternalName.BoardingTime] = BoardingTime;
            _item[FlightScheduleSpModelsField.InternalName.Origin] = Origin;
            _item[FlightScheduleSpModelsField.InternalName.Destination] = Destination;
            _item[FlightScheduleSpModelsField.InternalName.Route] = Route;
            _item[FlightScheduleSpModelsField.InternalName.FlightReg] = FlightReg;
            _item[FlightScheduleSpModelsField.InternalName.FlightAcType] = FlightAcType;
            _item[FlightScheduleSpModelsField.InternalName.FlightCreatedAt] = FlightCreatedAt;
            _item[FlightScheduleSpModelsField.InternalName.FlightUpdatedAt] = FlightUpdatedAt;

            _item[FlightScheduleSpModelsField.InternalName.FlightDateGMT0] = FlightDateGMT0;

            _item[FlightScheduleSpModelsField.InternalName.FlightDateGMT5] = FlightDateGMT5;

            _item[FlightScheduleSpModelsField.InternalName.FlightDateGMT7] = FlightDateGMT7;

            _item[FlightScheduleSpModelsField.InternalName.FlightDate] = FlightDate;

            _item[FlightScheduleSpModelsField.InternalName.DepartureDate] = DepartureDate;

            _item[FlightScheduleSpModelsField.InternalName.DepartureDateGMT0] = DepartureDateGMT0;

            _item[FlightScheduleSpModelsField.InternalName.DepartureDateGmt7] = DepartureDateGmt7;

            _item[FlightScheduleSpModelsField.InternalName.FlightEtd] = FlightEtd;

            _item[FlightScheduleSpModelsField.InternalName.FlightEtdGmt0] = FlightEtdGmt0;

            _item[FlightScheduleSpModelsField.InternalName.FlightEtdGmt7] = FlightEtdGmt7;

            _item[FlightScheduleSpModelsField.InternalName.FlightStd] = FlightStd;

            _item[FlightScheduleSpModelsField.InternalName.FlightStdGmt0] = FlightStdGmt0;

            _item[FlightScheduleSpModelsField.InternalName.FlightStdGmt7] = FlightStdGmt7;

            _item[FlightScheduleSpModelsField.InternalName.FlightEta] = FlightEta;

            _item[FlightScheduleSpModelsField.InternalName.FlightEtaGmt0] = FlightEtaGmt0;

            _item[FlightScheduleSpModelsField.InternalName.FlightEtaGmt7] = FlightEtaGmt7;

            _item[FlightScheduleSpModelsField.InternalName.FlightSta] = FlightSta;
            _item[FlightScheduleSpModelsField.InternalName.FlightStaGmt0] = FlightStaGmt0;

            _item[FlightScheduleSpModelsField.InternalName.FlightStaGmt7] = FlightStaGmt7;
            return this;
        }
        public class FlightScheduleSpModelsField
        {
            public static class InternalName
            {
                public const string FlightId = "Title";
                public const string FlightCreatedAt = "FlightCreatedAt";
                public const string FlightUpdatedAt = "FlightUpdatedAt";
                public const string AircraftId = "AircraftId";
                public const string FlightDateGMT0 = "FlightDateGMT0";
                public const string FlightDateGMT5 = "FlightDateGMT5";
                public const string FlightDateGMT7 = "FlightDateGMT7";
                public const string FlightDate = "FlightDate";
                public const string FlightNumber = "FlightNumber";
                public const string Status = "Status";
                public const string DepartureDate = "DepartureDate";
                public const string DepartureDateGMT0 = "DepartureDateGMT0";
                public const string DepartureDateGmt7 = "DepartureDateGmt7";
                public const string DepartureGate = "DepartureGate";
                public const string BoardingStatus = "BoardingStatus";
                public const string BoardingTime = "BoardingTime";
                public const string FlightEtd = "FlightEtd";
                public const string FlightEtdGmt0 = "FlightEtdGmt0";
                public const string FlightEtdGmt7 = "FlightEtdGmt7";
                public const string FlightStd = "FlightStd";
                public const string FlightStdGmt0 = "FlightStdGmt0";
                public const string FlightStdGmt7 = "FlightStdGmt7";
                public const string FlightEta = "FlightEta";
                public const string FlightEtaGmt0 = "FlightEtaGmt0";
                public const string FlightEtaGmt7 = "FlightEtaGmt7";
                public const string FlightSta = "FlightSta";
                public const string FlightStaGmt0 = "FlightStaGmt0";
                public const string FlightStaGmt7 = "FlightStaGmt7";
                public const string Origin = "Origin";
                public const string Destination = "Destination";
                public const string Route = "Route";
                public const string FlightReg = "FlightReg";
                public const string FlightAcType = "FlightAcType";
            }
        }
    }
}