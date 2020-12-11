using System;
using BambooAirwayBE.API.Data;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Models.SPModels
{
    public class TimeKeepingSPModels : BaseItem
    {
        public string DeviceName { get; set; }
        public string UserId { get; set; }
        public DateTime TimeKeepingDateTime { get; set; }
        public DateTime CreateTimeAt { get; set; }
        public DateTime UpdatedTimeAt { get; set; }
        public string EmployeeEmail { get; set; }
        public TimeKeepingSPModels(SPRespository respository, ListItem item) : base(respository, item)
        {
            if (item == null) return;
            DeviceName = item.FieldValues[TimeKeepingSPModelsField.InternalName.DeviceName]?.ToString();
            UserId = item.FieldValues[TimeKeepingSPModelsField.InternalName.UserId]?.ToString();
            if (item.FieldValues[TimeKeepingSPModelsField.InternalName.TimeKeepingDateTime] != null)
                TimeKeepingDateTime = Convert.ToDateTime(item.FieldValues[TimeKeepingSPModelsField.InternalName.TimeKeepingDateTime]);
            if (item.FieldValues[TimeKeepingSPModelsField.InternalName.CreateTimeAt] != null)
                CreateTimeAt = Convert.ToDateTime(item.FieldValues[TimeKeepingSPModelsField.InternalName.CreateTimeAt]);
            if (item.FieldValues[TimeKeepingSPModelsField.InternalName.UpdatedTimeAt] != null)
                UpdatedTimeAt = Convert.ToDateTime(item.FieldValues[TimeKeepingSPModelsField.InternalName.UpdatedTimeAt]);
            EmployeeEmail = item.FieldValues[TimeKeepingSPModelsField.InternalName.EmployeeEmail]?.ToString();
        }
        public override BaseItem SyncToSPItem()
        {
            if (_item == null) return this;
            _item[TimeKeepingSPModelsField.InternalName.UserId] = UserId;
            _item[TimeKeepingSPModelsField.InternalName.DeviceName] = DeviceName;
            _item[TimeKeepingSPModelsField.InternalName.TimeKeepingDateTime] = TimeKeepingDateTime;
            _item[TimeKeepingSPModelsField.InternalName.CreateTimeAt] = CreateTimeAt;
            _item[TimeKeepingSPModelsField.InternalName.UpdatedTimeAt] = UpdatedTimeAt;
            _item[TimeKeepingSPModelsField.InternalName.EmployeeEmail] = EmployeeEmail;
            return this;
        }

        public class TimeKeepingSPModelsField
        {
            public static class InternalName
            {
                public const string DeviceName = "DeviceName";
                public const string UserId = "Title";
                public const string TimeKeepingDateTime = "TimeKeepingDateTime";
                public const string CreateTimeAt = "CreateTimeAt";
                public const string UpdatedTimeAt = "UpdatedTimeAt";
                public const string EmployeeEmail = "EmployeeEmail";
            }
        }
    }
}