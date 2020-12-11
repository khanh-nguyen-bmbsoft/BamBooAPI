using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Models.ViewModels.FlightViewModels
{
    public class FlightPassengerDetailViewModels
    {
        public int Id { get; set; }
        public int? FlightPassengerDetailId { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? TicketId { get; set; }
        public int? PnrId { get; set; }
        public int? BookingId { get; set; }
        public LookupModels FlightScheduleId { get; set; }
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
    }

    public class FlightPassengerDetailRequestViewModels
    {
        public int? FlightPassengerDetailId { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? TicketId { get; set; }
        public int? PnrId { get; set; }
        public int? BookingId { get; set; }
        public LookupModels FlightScheduleId { get; set; }
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
    }
}