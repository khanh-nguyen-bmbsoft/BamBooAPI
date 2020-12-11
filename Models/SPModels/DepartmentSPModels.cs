using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirwayBE.API.Data;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Models.SPModels
{
    public class DepartmentSPModels : BaseItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public DepartmentSPModels(SPRespository respository, ListItem item) : base(respository, item)
        {
            if (item == null) return;
            Id = item.Id;
            Title = item.FieldValues[DepartmentSPModelsField.InternalName.Title]?.ToString();
            Code = item.FieldValues[DepartmentSPModelsField.InternalName.Code]?.ToString();
           
        }
        public override BaseItem SyncToSPItem()
        {
            if (_item == null) return this;
            _item[DepartmentSPModelsField.InternalName.Title] = Title;
            _item[DepartmentSPModelsField.InternalName.Code] = Code;
            return this;
        }

        public class DepartmentSPModelsField
        {
            public static class InternalName
            {
                public const string Title = "Title";
                public const string Code = "Code";
            }
        }
    }
}