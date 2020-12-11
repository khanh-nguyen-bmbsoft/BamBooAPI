using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirwayBE.API.Data;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Models.SPModels
{
    public class WorkingTimeSpModels : BaseItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public FieldLookupValue Department { get; set; }
        public string ShiftCode { get; set; }
        public string IncomeTime { get; set; }
        public string OutcomeTime { get; set; }
        public string DetailDepartment { get; set; }
        public WorkingTimeSpModels(SPRespository respository, ListItem item) : base(respository, item)
        {
            if (item == null) return;
            Id = item.Id;
            Title = item.FieldValues[WorkingTimeSpModelsField.InternalName.Title]?.ToString();
            Department = (!string.IsNullOrEmpty(Convert.ToString(item.FieldValues[WorkingTimeSpModelsField.InternalName.Department]))) ?
                (FieldLookupValue)item.FieldValues[WorkingTimeSpModelsField.InternalName.Department] : new FieldLookupValue() { LookupId = 0 };
            ShiftCode = item.FieldValues[WorkingTimeSpModelsField.InternalName.ShiftCode]?.ToString();
            IncomeTime = item.FieldValues[WorkingTimeSpModelsField.InternalName.IncomeTime]?.ToString();
            OutcomeTime = item.FieldValues[WorkingTimeSpModelsField.InternalName.OutcomeTime]?.ToString();
            DetailDepartment = item.FieldValues[WorkingTimeSpModelsField.InternalName.DetailDepartment]?.ToString();
        }
        public override BaseItem SyncToSPItem()
        {
            if (_item == null) return this;
            _item[WorkingTimeSpModelsField.InternalName.Title] = Title;
            _item[WorkingTimeSpModelsField.InternalName.Department] = Department;
            _item[WorkingTimeSpModelsField.InternalName.ShiftCode] = ShiftCode;
            _item[WorkingTimeSpModelsField.InternalName.IncomeTime] = IncomeTime;
            _item[WorkingTimeSpModelsField.InternalName.OutcomeTime] = OutcomeTime;
            _item[WorkingTimeSpModelsField.InternalName.DetailDepartment] = DetailDepartment;
            return this;

        }

        public class WorkingTimeSpModelsField
        {
            public static class InternalName
            {
                public const string Title = "Title";
                public const string Code = "Code";
                public const string Department = "Department";
                public const string ShiftCode = "ShiftCode";
                public const string IncomeTime = "IncomeTime";
                public const string OutcomeTime = "OutcomeTime";
                public const string DetailDepartment = "DetailDepartment";
            }
        }
    }
}