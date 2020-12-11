using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirewayBE.API.Helper;
using BambooAirwayBE.API.Data;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Models.SPModels.FlightView
{
    public class FlightPassengerDetailSpModels : BaseItem
    {
        public int Id { get; set; }
        public int? FlightPassengerDetailId { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? TicketId { get; set; }
        public int? PnrId { get; set; }
        public int? BookingId { get; set; }
        public FieldLookupValue FlightScheduleId { get; set; }
        public string CabinClass { get; set; }
        public string SeatNumber { get; set; }
        public string CheckingStatus { get; set; }
        public string PaxType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassengerName { get; set; }
        public string Age { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ReservationStatus { get; set; }
        public string FfpNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberCountryCode { get; set; }
        public string SegmentStatus { get; set; }
        public string InfantIndicator { get; set; }
        public string SsrCode { get; set; }
        public DateTime? FlightAt { get; set; }
        public DateTime? CheckinAt { get; set; }
        public int? TicketNumber { get; set; }
        public string PnrNumber { get; set; }
        public string PnrCreator { get; set; }
        public int? FlightNumber { get; set; }
        public DateTime? FlightDate { get; set; }

        public FlightPassengerDetailSpModels(SPRespository respository, ListItem item) : base(respository, item)
        {
            if (item == null) return;
            Id = item.Id;
            if (item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.FlightPassengerDetailId] != null)
                FlightPassengerDetailId = Convert.ToInt32(item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.FlightPassengerDetailId]);
            CabinClass = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.CabinClass]?.ToString();
            SeatNumber = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.SeatNumber]?.ToString();
            CheckingStatus = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.CheckingStatus]?.ToString();
            PaxType = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.PaxType]?.ToString();
            FirstName = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.FirstName]?.ToString();
            LastName = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.LastName]?.ToString();
            PassengerName = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.PassengerName]?.ToString();
            Age = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.Age]?.ToString();
            Gender = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.Gender]?.ToString();
            ReservationStatus = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.ReservationStatus]?.ToString();
            FfpNumber = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.FfpNumber]?.ToString();
            Email = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.Email]?.ToString();
            PhoneNumber = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.PhoneNumber]?.ToString();
            PhoneNumberCountryCode = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.PhoneNumberCountryCode]?.ToString();
            SegmentStatus = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.SegmentStatus]?.ToString();
            InfantIndicator = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.InfantIndicator]?.ToString();
            SsrCode = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.SsrCode]?.ToString();
            PnrNumber = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.PnrNumber]?.ToString();
            PnrCreator = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.PnrCreator]?.ToString();
            if (item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.CreateAt] != null)
                CreateAt =DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.CreateAt]));
            if (item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.UpdatedAt] != null)
                UpdatedAt = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.UpdatedAt]));

            if (item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.TicketId] != null)
                TicketId = Convert.ToInt32(item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.TicketId]);
            if (item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.PnrId] != null)
                PnrId = Convert.ToInt32(item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.PnrId]);
            if (item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.BookingId] != null)
                BookingId = Convert.ToInt32(item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.BookingId]);

            if (item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.DateOfBirth] != null)
                DateOfBirth = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.DateOfBirth]));

            if (item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.FlightAt] != null)
                FlightAt = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.FlightAt]));

            if (item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.CheckinAt] != null)
                CheckinAt = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.CheckinAt]));

            if (item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.TicketNumber] != null)
                TicketNumber = Convert.ToInt32(item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.TicketNumber]);

            if (item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.FlightNumber] != null)
                FlightNumber = Convert.ToInt32(item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.FlightNumber]);

            if (item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.FlightDate] != null)
                FlightDate = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.FlightDate]));

            if (item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.FlightScheduleId] != null)
                FlightScheduleId = item.FieldValues[FlightPassengerDetailSpModelsField.InternalName.FlightScheduleId] as FieldLookupValue;

        }

        public override BaseItem SyncToSPItem()
        {
            if (_item == null) return this;
            _item[FlightPassengerDetailSpModelsField.InternalName.Title] = Title;
            _item[FlightPassengerDetailSpModelsField.InternalName.FlightPassengerDetailId] = FlightPassengerDetailId;
            _item[FlightPassengerDetailSpModelsField.InternalName.CabinClass] = CabinClass;
            _item[FlightPassengerDetailSpModelsField.InternalName.SeatNumber] = SeatNumber;
            _item[FlightPassengerDetailSpModelsField.InternalName.CheckingStatus] = CheckingStatus;
            _item[FlightPassengerDetailSpModelsField.InternalName.PaxType] = PaxType;
            _item[FlightPassengerDetailSpModelsField.InternalName.FirstName] = FirstName;
            _item[FlightPassengerDetailSpModelsField.InternalName.LastName] = LastName;
            _item[FlightPassengerDetailSpModelsField.InternalName.PassengerName] = PassengerName;
            _item[FlightPassengerDetailSpModelsField.InternalName.Age] = Age;
            _item[FlightPassengerDetailSpModelsField.InternalName.Gender] = Gender;
            _item[FlightPassengerDetailSpModelsField.InternalName.ReservationStatus] = ReservationStatus;
            _item[FlightPassengerDetailSpModelsField.InternalName.FfpNumber] = FfpNumber;
            _item[FlightPassengerDetailSpModelsField.InternalName.Email] = Email;
            _item[FlightPassengerDetailSpModelsField.InternalName.PhoneNumber] = PhoneNumber;
            _item[FlightPassengerDetailSpModelsField.InternalName.PhoneNumberCountryCode] = PhoneNumberCountryCode;
            _item[FlightPassengerDetailSpModelsField.InternalName.SegmentStatus] = SegmentStatus;
            _item[FlightPassengerDetailSpModelsField.InternalName.InfantIndicator] = InfantIndicator;
            _item[FlightPassengerDetailSpModelsField.InternalName.SsrCode] = SsrCode;
            _item[FlightPassengerDetailSpModelsField.InternalName.PnrNumber] = PnrNumber;
            _item[FlightPassengerDetailSpModelsField.InternalName.PnrCreator] = PnrCreator;
            _item[FlightPassengerDetailSpModelsField.InternalName.CreateAt] = CreateAt;
            _item[FlightPassengerDetailSpModelsField.InternalName.UpdatedAt] = UpdatedAt;
            _item[FlightPassengerDetailSpModelsField.InternalName.TicketId] = TicketId;
            _item[FlightPassengerDetailSpModelsField.InternalName.PnrId] = PnrId;
            _item[FlightPassengerDetailSpModelsField.InternalName.BookingId] = BookingId;
            _item[FlightPassengerDetailSpModelsField.InternalName.DateOfBirth] = DateOfBirth;
            _item[FlightPassengerDetailSpModelsField.InternalName.FlightAt] = FlightAt;
            _item[FlightPassengerDetailSpModelsField.InternalName.CheckinAt] = CheckinAt;
            _item[FlightPassengerDetailSpModelsField.InternalName.TicketNumber] = TicketNumber;
            _item[FlightPassengerDetailSpModelsField.InternalName.FlightNumber] = FlightNumber;
            _item[FlightPassengerDetailSpModelsField.InternalName.FlightDate] = FlightDate;
            _item[FlightPassengerDetailSpModelsField.InternalName.FlightScheduleId] = FlightScheduleId;
            return this;
        }
        public class FlightPassengerDetailSpModelsField
        {
            public static class InternalName
            {
                public const string Title = "Title";
                public const string FlightPassengerDetailId = "FlightPassengerDetailId";
                public const string CreateAt = "CreateAt";
                public const string UpdatedAt = "UpdatedAt";
                public const string TicketId = "TicketId";
                public const string PnrId = "PnrId";
                public const string BookingId = "BookingId";
                public const string FlightScheduleId = "FlightScheduleId";
                public const string CabinClass = "CabinClass";
                public const string SeatNumber = "SeatNumber";
                public const string CheckingStatus = "CheckingStatus";
                public const string PaxType = "PaxType";
                public const string FirstName = "FirstName";
                public const string LastName = "LastName";
                public const string PassengerName = "PassengerName";
                public const string Age = "Age";
                public const string Gender = "Gender";
                public const string DateOfBirth = "DateOfBirth";
                public const string ReservationStatus = "ReservationStatus";
                public const string FfpNumber = "FfpNumber";
                public const string Email = "Email";
                public const string PhoneNumber = "PhoneNumber";
                public const string PhoneNumberCountryCode = "PhoneNumberCountryCode";
                public const string SegmentStatus = "SegmentStatus";
                public const string InfantIndicator = "InfantIndicator";
                public const string SsrCode = "SsrCode";
                public const string FlightAt = "FlightAt";
                public const string CheckinAt = "CheckinAt";
                public const string TicketNumber = "TicketNumber";
                public const string PnrNumber = "PnrNumber";
                public const string PnrCreator = "PnrCreator";
                public const string FlightNumber = "FlightNumber";
                public const string FlightDate = "FlightDate";
            }
        }
    }
}