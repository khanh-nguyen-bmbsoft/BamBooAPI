using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BambooAirewayBE.API.Models.ViewModels.FlightAttendant
{
    public class ReviewCategoryViewModels
    {
        public int Id { get; set; }
        public LookupModels ReviewCategoryId { get; set; }
        public string Phase { get; set; }
        public string EvaluationCriteria { get; set; }
        public string Satisfy { get; set; }
        public string NotSatisfy { get; set; }
        public string NeedImprove { get; set; }
        public string Detail { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? EffectiveToDate { get; set; }
        public LookupModels CreatedUser { get; set; }
        public LookupModels BeReviewedUser { get; set; }
        public string[] Status { get; set; }
    }
    public class ReviewCategoryRequestViewModels
    {
        public LookupModels ReviewCategoryId { get; set; }
        public string Phase { get; set; }
        public string EvaluationCriteria { get; set; }
        public string Satisfy { get; set; }
        public string NotSatisfy { get; set; }
        public string NeedImprove { get; set; }
        public string Detail { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? EffectiveToDate { get; set; }
        public LookupModels CreatedUser { get; set; }
        public LookupModels BeReviewedUser { get; set; }
        public string[] Status { get; set; }
    }
}