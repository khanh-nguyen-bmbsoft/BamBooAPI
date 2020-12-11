using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BambooAirewayBE.API.Models.ViewModels
{
    public class WorkingTimeViewModels
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string ShiftCode { get; set; }
        public string IncomeTime { get; set; }
        public string OutcomeTime { get; set; }
        public string DetailDepartment { get; set; }
    }

    public class WorkingTimeRequestModels
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DepartmentId { get; set; }
        public string ShiftCode { get; set; }
        public string IncomeTime { get; set; }
        public string OutcomeTime { get; set; }
        public string DetailDepartment { get; set; }
    }
}