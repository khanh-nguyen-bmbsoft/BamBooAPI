using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirwayBE.API.Data;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Models.SPModels.FlightAttendant
{
    public class TitleTemplateSpModels : BaseItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }

        public TitleTemplateSpModels(SPRespository respository, ListItem item) : base(respository, item)
        {
            if (item == null) return;
            Id = item.Id;
            Title = item.FieldValues[TitleTemplateField.InternalName.Title]?.ToString();
            Code = item.FieldValues[TitleTemplateField.InternalName.Title]?.ToString();
        }
        public override BaseItem SyncToSPItem()
        {
            if (_item == null) return this;
            _item[TitleTemplateField.InternalName.Title] = Title;
            _item[TitleTemplateField.InternalName.Code] = Code;
            return this;
        }
        public class TitleTemplateField
        {
            public static class InternalName
            {
                public const string Title = "Title";
                public const string Code = "Code";
            }
        }
    }
}