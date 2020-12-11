using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirewayBE.API.Helper;
using BambooAirwayBE.API.Data;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Models.SPModels.FlightView
{
    public class FlightCrewSpModels : BaseItem
    {
        public int Id { get; set; }
        public string FlightCrewId { get; set; }
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
        public FieldLookupValue FlightScheduleId { get; set; }
        public DateTime? FlightDate { get; set; }
        public FlightCrewSpModels(SPRespository respository, ListItem item) : base(respository, item)
        {
            if (item == null) return;
            Id = item.Id;
            FlightCrewId = item.FieldValues[FlightCrewSpModelsField.InternalName.FlightCrewId]?.ToString();
            FirstName = item.FieldValues[FlightCrewSpModelsField.InternalName.FirstName]?.ToString();
            LastName = item.FieldValues[FlightCrewSpModelsField.InternalName.LastName]?.ToString();
            ShortName = item.FieldValues[FlightCrewSpModelsField.InternalName.ShortName]?.ToString();
            Location = item.FieldValues[FlightCrewSpModelsField.InternalName.Location]?.ToString();
            Quals = item.FieldValues[FlightCrewSpModelsField.InternalName.Quals]?.ToString();
            Sex = item.FieldValues[FlightCrewSpModelsField.InternalName.Sex]?.ToString();
            Marital = item.FieldValues[FlightCrewSpModelsField.InternalName.Marital]?.ToString();
            NationalityCode = item.FieldValues[FlightCrewSpModelsField.InternalName.NationalityCode]?.ToString();
            Nationality = item.FieldValues[FlightCrewSpModelsField.InternalName.Nationality]?.ToString();
            ZipCode = item.FieldValues[FlightCrewSpModelsField.InternalName.ZipCode]?.ToString();
            City = item.FieldValues[FlightCrewSpModelsField.InternalName.City]?.ToString();
            State = item.FieldValues[FlightCrewSpModelsField.InternalName.State]?.ToString();
            ContactCell = item.FieldValues[FlightCrewSpModelsField.InternalName.ContactCell]?.ToString();
            Email = item.FieldValues[FlightCrewSpModelsField.InternalName.Email]?.ToString();
            NextKinName = item.FieldValues[FlightCrewSpModelsField.InternalName.NextKinName]?.ToString();
            NextKinRelsn = item.FieldValues[FlightCrewSpModelsField.InternalName.NextKinRelsn]?.ToString();
            NextKinContact = item.FieldValues[FlightCrewSpModelsField.InternalName.NextKinContact]?.ToString();
            Address = item.FieldValues[FlightCrewSpModelsField.InternalName.Address]?.ToString();
            Language = item.FieldValues[FlightCrewSpModelsField.InternalName.Language]?.ToString();
            Language2 = item.FieldValues[FlightCrewSpModelsField.InternalName.Language2]?.ToString();
            LicenceNum = item.FieldValues[FlightCrewSpModelsField.InternalName.LicenceNum]?.ToString();
            Position = item.FieldValues[FlightCrewSpModelsField.InternalName.Position]?.ToString();
            FlightScheduleId = item.FieldValues[FlightCrewSpModelsField.InternalName.FlightScheduleId] as FieldLookupValue;
            
            if (item.FieldValues[FlightCrewSpModelsField.InternalName.FlightCrewCreatedAt] != null)
                FlightCrewCreatedAt =DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightCrewSpModelsField.InternalName.FlightCrewCreatedAt]));
            if (item.FieldValues[FlightCrewSpModelsField.InternalName.FlightCrewUpdatedAt] != null)
                FlightCrewUpdatedAt = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightCrewSpModelsField.InternalName.FlightCrewUpdatedAt]));
            if (item.FieldValues[FlightCrewSpModelsField.InternalName.AimsId] != null)
                AimsId = Convert.ToInt32(item.FieldValues[FlightCrewSpModelsField.InternalName.AimsId]);
            if (item.FieldValues[FlightCrewSpModelsField.InternalName.ContactTel] != null)
                ContactTel = Convert.ToInt32(item.FieldValues[FlightCrewSpModelsField.InternalName.ContactTel]);

            if (item.FieldValues[FlightCrewSpModelsField.InternalName.UserId] != null)
                UserId = Convert.ToInt32(item.FieldValues[FlightCrewSpModelsField.InternalName.UserId]);

            if (item.FieldValues[FlightCrewSpModelsField.InternalName.EmploymentDate] != null)
                EmploymentDate = Convert.ToDateTime(item.FieldValues[FlightCrewSpModelsField.InternalName.EmploymentDate]);

            if (item.FieldValues[FlightCrewSpModelsField.InternalName.CrewId] != null)
                CrewId = Convert.ToInt32(item.FieldValues[FlightCrewSpModelsField.InternalName.CrewId]);

            if (item.FieldValues[FlightCrewSpModelsField.InternalName.Ac] != null)
                Ac = Convert.ToInt32(item.FieldValues[FlightCrewSpModelsField.InternalName.Ac]);

            if (item.FieldValues[FlightCrewSpModelsField.InternalName.FlightNumber] != null)
                FlightNumber = Convert.ToInt32(item.FieldValues[FlightCrewSpModelsField.InternalName.FlightNumber]);

            if (item.FieldValues[FlightCrewSpModelsField.InternalName.FlightDate] != null)
                FlightDate = DateTimeHelper.ConvertToLocalDatetime(Convert.ToDateTime(item.FieldValues[FlightCrewSpModelsField.InternalName.FlightDate]));
        }
        public override BaseItem SyncToSPItem()
        {
            if (_item == null) return this;
            _item[FlightCrewSpModelsField.InternalName.FlightCrewId] = FlightCrewId;
            _item[FlightCrewSpModelsField.InternalName.FlightCrewCreatedAt] = FlightCrewCreatedAt;
            _item[FlightCrewSpModelsField.InternalName.FlightCrewUpdatedAt] = FlightCrewUpdatedAt;
            _item[FlightCrewSpModelsField.InternalName.AimsId] = AimsId;
            _item[FlightCrewSpModelsField.InternalName.Name] = Name;
            _item[FlightCrewSpModelsField.InternalName.FirstName] = FirstName;
            _item[FlightCrewSpModelsField.InternalName.LastName] = LastName;
            _item[FlightCrewSpModelsField.InternalName.ShortName] = ShortName;
            _item[FlightCrewSpModelsField.InternalName.Location] = Location;
            _item[FlightCrewSpModelsField.InternalName.Quals] = Quals;
            _item[FlightCrewSpModelsField.InternalName.Sex] = Sex;
            _item[FlightCrewSpModelsField.InternalName.Marital] = Marital;
            _item[FlightCrewSpModelsField.InternalName.NationalityCode] = NationalityCode;
            _item[FlightCrewSpModelsField.InternalName.Nationality] = Nationality;
            _item[FlightCrewSpModelsField.InternalName.ZipCode] = ZipCode;
            _item[FlightCrewSpModelsField.InternalName.City] = City;
            _item[FlightCrewSpModelsField.InternalName.State] = State;
            _item[FlightCrewSpModelsField.InternalName.ContactCell] = ContactCell;
            _item[FlightCrewSpModelsField.InternalName.ContactTel] = ContactTel;
            _item[FlightCrewSpModelsField.InternalName.Email] = Email;
            _item[FlightCrewSpModelsField.InternalName.NextKinName] = NextKinName;
            _item[FlightCrewSpModelsField.InternalName.NextKinRelsn] = NextKinRelsn;
            _item[FlightCrewSpModelsField.InternalName.NextKinContact] = NextKinContact;
            _item[FlightCrewSpModelsField.InternalName.UserId] = UserId;
            _item[FlightCrewSpModelsField.InternalName.Address] = Address;
            _item[FlightCrewSpModelsField.InternalName.EmploymentDate] = EmploymentDate;
            _item[FlightCrewSpModelsField.InternalName.Language] = Language;
            _item[FlightCrewSpModelsField.InternalName.Language2] = Language2;
            _item[FlightCrewSpModelsField.InternalName.LicenceNum] = LicenceNum;
            _item[FlightCrewSpModelsField.InternalName.CrewId] = CrewId;
            _item[FlightCrewSpModelsField.InternalName.Position] = Position;
            _item[FlightCrewSpModelsField.InternalName.Ac] = Ac;
            _item[FlightCrewSpModelsField.InternalName.FlightNumber] = FlightNumber;
            _item[FlightCrewSpModelsField.InternalName.FlightDate] = FlightDate;
            _item[FlightCrewSpModelsField.InternalName.FlightScheduleId] = FlightScheduleId;
            return this;
        }
        public class FlightCrewSpModelsField
        {
            public static class InternalName
            {
                public const string FlightCrewId = "Title";
                public const string FlightCrewCreatedAt = "FlightCrewCreatedAt";
                public const string FlightCrewUpdatedAt = "FlightCrewUpdatedAt";
                public const string AimsId = "AimsId";
                public const string Name = "Name";
                public const string FirstName = "FirstName";
                public const string LastName = "LastName";
                public const string ShortName = "ShortName";
                public const string Location = "Location";
                public const string Quals = "Quals";
                public const string Sex = "Sex";
                public const string Marital = "Marital";
                public const string NationalityCode = "NationalityCode";
                public const string Nationality = "Nationality";
                public const string ZipCode = "ZipCode";
                public const string City = "City";
                public const string State = "State";
                public const string ContactCell = "ContactCell";
                public const string ContactTel = "ContactTel";
                public const string Email = "Email";
                public const string NextKinName = "NextKinName";
                public const string NextKinRelsn = "NextKinRelsn";
                public const string NextKinContact = "NextKinContact";
                public const string UserId = "UserId";
                public const string Address = "Address";
                public const string EmploymentDate = "EmploymentDate";
                public const string Language = "Language";
                public const string Language2 = "Language2";
                public const string LicenceNum = "LicenceNum";
                public const string CrewId = "CrewId";
                public const string Position = "Position";
                public const string Ac = "Ac";
                public const string FlightNumber = "FlightNumber";
                public const string FlightDate = "FlightDate";
                public const string FlightScheduleId = "FlightScheduleId";

            }
        }
    }
}