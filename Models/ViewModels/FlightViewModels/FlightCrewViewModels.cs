using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BambooAirewayBE.API.Models.ViewModels.FlightViewModels
{
    public class FlightCrewViewModels
    {
        public int Id { get; set; }
        public int FlightCrewId { get; set; }
        public DateTime? FlightCrewCreatedAt { get; set; }
        public DateTime? FlightCrewUpdatedAt { get; set; }
        public int? AimsId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortName { get; set; }
        public string Location { get; set; }
        public string Quals { get; set; }
        public string Sex { get; set; }
        public string Marital { get; set; }
        public string NationalityCode { get; set; }
        public string Nationality { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ContactCell { get; set; }
        public int? ContactTel { get; set; }
        public string Email { get; set; }
        public string NextKinName { get; set; }
        public string NextKinRelsn { get; set; }
        public string NextKinContact { get; set; }
        public int? UserId { get; set; }
        public string Address { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public string Language { get; set; }
        public string Language2 { get; set; }
        public string LicenceNum { get; set; }
        public int? CrewId { get; set; }
        public string Position { get; set; }
        public int? Ac { get; set; }
        public int? FlightNumber { get; set; }
        public DateTime? FlightDate { get; set; }
    }

    public class FlightCrewGetFlDateAndFlNumber
    {
        public int FlightNumber { get; set; }
        public DateTime FlightDate { get; set; }
    }
    public class FlightCrewRequestViewModels
    {
        public int FlightCrewId { get; set; }
        public DateTime? FlightCrewCreatedAt { get; set; }
        public DateTime? FlightCrewUpdatedAt { get; set; }
        public int? AimsId { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ShortName { get; set; }
        public string Location { get; set; }
        public string Quals { get; set; }
        public string Sex { get; set; }
        public string Marital { get; set; }
        public string NationalityCode { get; set; }
        public string Nationality { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ContactCell { get; set; }
        public int? ContactTel { get; set; }
        public string Email { get; set; }
        public string NextKinName { get; set; }
        public string NextKinRelsn { get; set; }
        public string NextKinContact { get; set; }
        public int? UserId { get; set; }
        public string Address { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public string Language { get; set; }
        public string Language2 { get; set; }
        public string LicenceNum { get; set; }
        public int? CrewId { get; set; }
        public string Position { get; set; }
        public int? Ac { get; set; }
        public int? FlightNumber { get; set; }
        public DateTime? FlightDate { get; set; }
    }
}