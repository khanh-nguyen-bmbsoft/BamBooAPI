using System;
using System.Collections.Generic;
using BambooAirewayBE.API.Helper;
using BambooAirewayBE.API.Models.SPModels;
using BambooAirewayBE.API.Models.ViewModels;
using BambooAirewayBE.API.Utilities.ListConstant;
using BambooAirwayBE.API.Data;
using BambooAirwayBE.API.Utilities.Utils;
using Microsoft.SharePoint.Client;
using WebGrease.Css.Extensions;

namespace BambooAirwayBE.API.Job
{
    public class TimeKeepingJob
    {
        private static ClientContext _clientContext;
        public TimeKeepingJob(ClientContext client)
        {
            _clientContext = client;
        }

        public ApiResponse<TimeKeepingViewModels> GetAllTimeKeeping()
        {
            var apiResponse = new ApiResponse<TimeKeepingViewModels>();
            try
            {
                var listDepartment = new List<TimeKeepingViewModels>();
                var getAllItem = Utils.GetTimeKeeping(_clientContext);
                getAllItem?.ForEach(x =>
                {
                    var viewModel = new TimeKeepingViewModels
                    {
                        DeviceName = x.DeviceName,
                        UserId = x.UserId,
                        TimeKeepingDateTime = x.TimeKeepingDateTime,
                        CreateTimeAt = x.CreateTimeAt,
                        UpdatedTimeAt = x.UpdatedTimeAt,
                        EmployeeEmail = x.EmployeeEmail
                    };
                    listDepartment.Add(viewModel);
                });
                apiResponse.Content = listDepartment;
                return apiResponse;
            }
            catch (Exception e)
            {
                apiResponse.ErrorType = 400;
                apiResponse.ErrorMessage = new[] { e.Message };
                return apiResponse;
            }
        }
        public ApiResponse<string> InsertTimeKeeping(List<TimeKeepingInsertModels> data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<string>();
            var arrMessage = new List<string>();
            try
            {
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListTimeKeeping));
                foreach (var x in data)
                {
                    try
                    {
                        var newItem = new TimeKeepingSPModels(res, null)
                        {
                            DeviceName = x.device_name,
                            UserId = x.user_id,
                            TimeKeepingDateTime =Convert.ToDateTime(x.date + " " + x.time),
                            CreateTimeAt = x.created_at,
                            UpdatedTimeAt = x.updated_at,
                            EmployeeEmail = x.user_email
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