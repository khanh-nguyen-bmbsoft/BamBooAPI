using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirwayBE.API.Data;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Models.SPModels.FlightAttendant
{
    public class ResultDetailFlightAttendantSpModels : BaseItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public FieldLookupValue EmployeeCode { get; set; }
        public string Result { get; set; }
        public double? Avarage { get; set; }
        public string Note { get; set; }
        public int? Deadline { get; set; }
        public FieldLookupValue Assessor { get; set; }

        public ResultDetailFlightAttendantSpModels(SPRespository respository, ListItem item) : base(respository, item)
        {
            if (item == null) return;
            Id = item.Id;
            Title = item.FieldValues[ResultDetailFlightAttendantField.InternalName.Title]?.ToString();
            EmployeeCode = item.FieldValues[ResultDetailFlightAttendantField.InternalName.EmployeeCode] as FieldLookupValue;
            Result = item.FieldValues[ResultDetailFlightAttendantField.InternalName.Result]?.ToString();
            Note = item.FieldValues[ResultDetailFlightAttendantField.InternalName.Note]?.ToString();
            if (item.FieldValues[ResultDetailFlightAttendantField.InternalName.Avarage] != null)
                Avarage = Convert.ToDouble(item.FieldValues[ResultDetailFlightAttendantField.InternalName.Avarage]);
            if (item.FieldValues[ResultDetailFlightAttendantField.InternalName.Assessor] != null)
                Assessor = item.FieldValues[ResultDetailFlightAttendantField.InternalName.Assessor] as FieldLookupValue;
            if (item.FieldValues[ResultDetailFlightAttendantField.InternalName.Deadline] != null)
                Deadline = Convert.ToInt32(item.FieldValues[ResultDetailFlightAttendantField.InternalName.Deadline]);
        }
        public override BaseItem SyncToSPItem()
        {
            if (_item == null) return this;
            _item[ResultDetailFlightAttendantField.InternalName.Title] = EmployeeCode.LookupId;
            _item[ResultDetailFlightAttendantField.InternalName.EmployeeCode] = EmployeeCode;
            _item[ResultDetailFlightAttendantField.InternalName.Result] = Result;
            _item[ResultDetailFlightAttendantField.InternalName.Avarage] = Avarage;
            _item[ResultDetailFlightAttendantField.InternalName.Note] = Note;
            _item[ResultDetailFlightAttendantField.InternalName.Deadline] = Deadline;
            _item[ResultDetailFlightAttendantField.InternalName.Assessor] = Assessor;
            return this;
        }
        public class ResultDetailFlightAttendantField
        {
            public static class InternalName
            {
                public const string Title = "Title";
                public const string EmployeeCode = "EmployeeCode";
                public const string Result = "Result";
                public const string Avarage = "Avarage";
                public const string Note = "Note";
                public const string Deadline = "Deadline";
                public const string Assessor = "Assessor";
            }
        }
    }
}