using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirewayBE.API.Helper;
using BambooAirewayBE.API.Models.SPModels;
using BambooAirewayBE.API.Models.ViewModels;
using BambooAirewayBE.API.Utilities.Constants;
using BambooAirewayBE.API.Utilities.ListConstant;
using BambooAirwayBE.API.Data;
using BambooAirwayBE.API.Utilities.Utils;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Job
{
    public class WorkingTimeJob
    {
        private static ClientContext _clientContext;
        public WorkingTimeJob(ClientContext client)
        {
            _clientContext = client;
        }
        public ApiResponse<WorkingTimeViewModels> GetAllWorkingTime()
        {
            var apiResponse = new ApiResponse<WorkingTimeViewModels>();
            try
            {
                var listItems = new List<WorkingTimeViewModels>();
                var getItems = Utils.GetWorkingTime(_clientContext);
                foreach (var x in getItems)
                {
                    var departmentViewModel = new WorkingTimeViewModels
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Department = x.Department.LookupValue,
                        ShiftCode = x.ShiftCode,
                        IncomeTime = x.IncomeTime,
                        OutcomeTime = x.OutcomeTime,
                        DetailDepartment = x.DetailDepartment
                    };
                    listItems.Add(departmentViewModel);
                }
                apiResponse.Content = listItems;
                return apiResponse;
            }
            catch (Exception e)
            {
                apiResponse.ErrorType = 400;
                apiResponse.ErrorMessage = new[] { e.Message };
                return apiResponse;
            }
        }
        public ApiResponse<string> InsertWorkingTime(List<WorkingTimeRequestModels> data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<string>();
            var arrMessage = new List<string>();
            try
            {
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListWorkingTime));
                foreach (var x in data)
                {
                    try
                    {
                        var newItem = new WorkingTimeSpModels(res, null)
                        {
                            Title = x.Title,
                            ShiftCode = x.ShiftCode,
                            IncomeTime = x.IncomeTime,
                            OutcomeTime = x.OutcomeTime,
                            DetailDepartment = x.DetailDepartment
                        };
                        if (x.DepartmentId > 0)
                            newItem.Department = new FieldLookupValue
                            {
                                LookupId = x.DepartmentId,
                            };
                        res.AddOrUpdate(newItem);
                    }
                    catch (Exception e)
                    {
                        arrMessage.Add(e.Message);
                        apiResponse.ErrorType = 400;
                        apiResponse.ErrorMessage = arrMessage;
                    }
                }
                return apiResponse;
            }
            catch (Exception e)
            {
                arrMessage.Add(e.Message);
                apiResponse.ErrorType = 400;
                apiResponse.ErrorMessage = arrMessage;
                return apiResponse;
            }
        }
    }
}