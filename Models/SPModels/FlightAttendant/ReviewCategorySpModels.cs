using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirwayBE.API.Data;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Models.SPModels.FlightAttendant
{
    public class ReviewCategorySpModels : BaseItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public FieldLookupValue ReviewCategoryId { get; set; }
        public string Phase { get; set; }
        public string EvaluationCriteria { get; set; }
        public string Satisfy { get; set; }
        public string NotSatisfy { get; set; }
        public string NeedImprove { get; set; }
        public string Detail { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? EffectiveToDate { get; set; }
        public FieldLookupValue CreatedUser { get; set; }
        public FieldLookupValue BeReviewedUser { get; set; }
        public string[] Status { get; set; }
        public ReviewCategorySpModels(SPRespository respository, ListItem item) : base(respository, item)
        {
            if (item == null) return;
            Id = item.Id;
            Title = item.FieldValues[ReviewCategoryField.InternalName.Title]?.ToString();
            ReviewCategoryId = item.FieldValues[ReviewCategoryField.InternalName.ReviewCategoryId] as FieldLookupValue;
            Phase = item.FieldValues[ReviewCategoryField.InternalName.Phase]?.ToString();
            EvaluationCriteria = item.FieldValues[ReviewCategoryField.InternalName.EvaluationCriteria]?.ToString();
            Satisfy = item.FieldValues[ReviewCategoryField.InternalName.Satisfy]?.ToString();
            NotSatisfy = item.FieldValues[ReviewCategoryField.InternalName.NotSatisfy]?.ToString();
            NeedImprove = item.FieldValues[ReviewCategoryField.InternalName.NeedImprove]?.ToString();
            Detail = item.FieldValues[ReviewCategoryField.InternalName.Detail]?.ToString();
            if (item.FieldValues[ReviewCategoryField.InternalName.EffectiveDate] != null)
                EffectiveDate = Convert.ToDateTime(item.FieldValues[ReviewCategoryField.InternalName.EffectiveDate]);

            if (item.FieldValues[ReviewCategoryField.InternalName.EffectiveToDate] != null)
                EffectiveToDate = Convert.ToDateTime(item.FieldValues[ReviewCategoryField.InternalName.EffectiveToDate]);

            if (item.FieldValues[ReviewCategoryField.InternalName.CreatedUser] != null)
                CreatedUser = item.FieldValues[ReviewCategoryField.InternalName.CreatedUser] as FieldLookupValue;

            if (item.FieldValues[ReviewCategoryField.InternalName.BeReviewedUser] != null)
                BeReviewedUser = item.FieldValues[ReviewCategoryField.InternalName.BeReviewedUser] as FieldLookupValue;

            if (item.FieldValues[ReviewCategoryField.InternalName.BeReviewedUser] != null)
                Status = item.FieldValues[ReviewCategoryField.InternalName.Status] as string[];

        }
        public override BaseItem SyncToSPItem()
        {
            if (_item == null) return this;
            _item[ReviewCategoryField.InternalName.Title] = ReviewCategoryId.LookupId;
            _item[ReviewCategoryField.InternalName.ReviewCategoryId] = ReviewCategoryId.LookupId;
            _item[ReviewCategoryField.InternalName.Phase] = Phase;
            _item[ReviewCategoryField.InternalName.EvaluationCriteria] = EvaluationCriteria;
            _item[ReviewCategoryField.InternalName.Satisfy] = Satisfy;
            _item[ReviewCategoryField.InternalName.NotSatisfy] = NotSatisfy;
            _item[ReviewCategoryField.InternalName.NeedImprove] = NeedImprove;
            _item[ReviewCategoryField.InternalName.Detail] = Detail;
            _item[ReviewCategoryField.InternalName.EffectiveDate] = EffectiveDate;
            _item[ReviewCategoryField.InternalName.EffectiveToDate] = EffectiveToDate;
            _item[ReviewCategoryField.InternalName.CreatedUser] = CreatedUser;
            _item[ReviewCategoryField.InternalName.BeReviewedUser] = BeReviewedUser;
            _item[ReviewCategoryField.InternalName.Status] = Status;
            return this;
        }
        public class ReviewCategoryField
        {
            public static class InternalName
            {
                public const string Title = "Title";
                public const string ReviewCategoryId = "ReviewCategoryId";
                public const string Phase = "Phase";
                public const string EvaluationCriteria = "EvaluationCriteria";
                public const string Satisfy = "Satisfy";
                public const string NotSatisfy = "NotSatisfy";
                public const string NeedImprove = "NeedImprove";
                public const string Detail = "Detail";
                public const string EffectiveDate = "EffectiveDate";
                public const string EffectiveToDate = "EffectiveToDate";
                public const string CreatedUser = "CreatedUser";
                public const string BeReviewedUser = "BeReviewedUser";
                public const string Status = "Status";
            }
        }
    }
}