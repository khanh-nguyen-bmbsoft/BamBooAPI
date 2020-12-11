using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BambooAirewayBE.API.Models.ViewModels.FlightViewModels
{
    public class FlightScheduleViewModels
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
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
    }

    public class GetByFlightDateRequest
    {
        public DateTime FlightDate { get; set; }
    }
    public class GetByFlightDateAndFlightNumberRequest
    {
        public DateTime FlightDate { get; set; }
        public string FlightNumber { get; set; }
    }
    public class FlightScheduleRequestViewModels
    {
        public int FlightId { get; set; }
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
    }
}