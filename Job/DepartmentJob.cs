using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirewayBE.API.Helper;
using BambooAirewayBE.API.Models.SPModels;
using BambooAirewayBE.API.Models.ViewModels;
using BambooAirewayBE.API.Utilities.ListConstant;
using BambooAirwayBE.API.Data;
using BambooAirwayBE.API.Utilities.Utils;
using WebGrease.Css.Extensions;

namespace BambooAirewayBE.API.Job
{
    public class DepartmentJob
    {
        private static ClientContext _clientContext;
        public DepartmentJob(ClientContext client)
        {
            _clientContext = client;
        }

        public ApiResponse<DepartmentViewModels> GetAllDepartment()
        {
            var apiResponse = new ApiResponse<DepartmentViewModels>();
            try
            {
                var listDepartment = new List<DepartmentViewModels>();
                var getDepartment = Utils.GetDepartment(_clientContext);
                getDepartment?.ForEach(x =>
                {
                    var departmentViewModel = new DepartmentViewModels { Id = x.Id, Code = x.Code, Title = x.Title };
                    listDepartment.Add(departmentViewModel);
                });
                apiResponse.Content = listDepartment;
                return apiResponse;
            }
            catch (Exception e)
            {
                apiResponse.ErrorType = 400;
                apiResponse.ErrorMessage = new []{ e.Message };
                return apiResponse;
            }
        }
        public ApiResponse<string> InsertDepartment(List<DepartmentRequestModels> data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<string>();
            var arrMessage = new List<string>();
            try
            {
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListDepartment));
                foreach (var x in data)
                {
                    try
                    {
                        var newItem = new DepartmentSPModels(res, null)
                        {
                            Title = x.Title,
                            Code = x.Code
                          
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