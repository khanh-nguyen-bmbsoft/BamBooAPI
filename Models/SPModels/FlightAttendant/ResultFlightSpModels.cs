using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirwayBE.API.Data;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Models.SPModels.FlightAttendant
{
    public class ResultFlightSpModels : BaseItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public FieldLookupValue StaffId { get; set; }
        public string IdentifyName { get; set; }
        public string FullName { get; set; }
        public string PositonName { get; set; }
        public string Result { get; set; }
        public double Avarage { get; set; }
        public string Note { get; set; }
        public FieldLookupValue Creator { get; set; }

        public ResultFlightSpModels(SPRespository respository, ListItem item) : base(respository, item)
        {
            if (item == null) return;
            Id = item.Id;
            Title = item.FieldValues[ResultFlightField.InternalName.Title]?.ToString();
            StaffId = item.FieldValues[ResultFlightField.InternalName.StaffId] as FieldLookupValue;
            IdentifyName = item.FieldValues[ResultFlightField.InternalName.IdentifyName]?.ToString();
            FullName = item.FieldValues[ResultFlightField.InternalName.FullName]?.ToString();
            PositonName = item.FieldValues[ResultFlightField.InternalName.PositonName]?.ToString();
            Result = item.FieldValues[ResultFlightField.InternalName.Result]?.ToString();
            Note = item.FieldValues[ResultFlightField.InternalName.Note]?.ToString();
            Avarage = Convert.ToDouble(item.FieldValues[ResultFlightField.InternalName.Avarage]);
        }

        public override BaseItem SyncToSPItem()
        {
            if (_item == null) return this;
            _item[ResultFlightField.InternalName.Title] = IdentifyName;
            _item[ResultFlightField.InternalName.StaffId] = StaffId;
            _item[ResultFlightField.InternalName.IdentifyName] = IdentifyName;
            _item[ResultFlightField.InternalName.FullName] = FullName;
            _item[ResultFlightField.InternalName.PositonName] = PositonName;
            _item[ResultFlightField.InternalName.Result] = Result;
            _item[ResultFlightField.InternalName.Avarage] = Avarage;
            _item[ResultFlightField.InternalName.Note] = Note;
            _item[ResultFlightField.InternalName.Creator] = Creator;
            return this;
        }
        public class ResultFlightField
        {
            public static class InternalName
            {
                public const string Title = "Title";
                public const string StaffId = "StaffId";
                public const string IdentifyName = "IdentifyName";
                public const string FullName = "FullName";
                public const string PositonName = "PositonName";
                public const string Result = "Result";
                public const string Avarage = "Avarage";
                public const string Note = "Note";
                public const string Creator = "Creator";
            }
        }
    }
}