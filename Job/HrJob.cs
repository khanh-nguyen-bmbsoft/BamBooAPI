using BambooAirewayBE.API.Helper;
using BambooAirewayBE.API.Models.SPModels;
using BambooAirewayBE.API.Models.ViewModels;
using BambooAirewayBE.API.Models.ViewRequests;
using BambooAirewayBE.API.Utilities.Constants;
using BambooAirewayBE.API.Utilities.ListConstant;
using BambooAirwayBE.API.Data;
using BambooAirwayBE.API.Utilities.Utils;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using BambooAirewayBE.API.Utilities.CalmQuery;
using Newtonsoft.Json;

namespace BambooAirewayBE.API.Job
{
    public class HrJob
    {
        private static ClientContext _clientContext;

        public HrJob(ClientContext client)
        {
            _clientContext = client;
        }

        public ApiResponse<HrViewModels> GetAllHr()
        {
            var apiResponse = new ApiResponse<HrViewModels>();
            try
            {
                var listItems = new List<HrViewModels>();
                var getItems = Utils.GetHr(_clientContext);
                foreach (var x in getItems)
                {
                    GetItemModels(listItems, x, _clientContext);
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

        private static void GetItemModels(List<HrViewModels> listItems, HrSpModels x, ClientContext clientContext)
        {
            var itemViewModel = new HrViewModels
            {
                Id = x.Id,
                EmployeeCode = x.EmployeeCode,
                FullName = x.FullName,
                CompanyEmail = x.CompanyEmail,
                NickName = x.NickName,
                PersonalPhone = x.PersonalPhone,
                PersonalEmail = x.PersonalEmail,
                DateOfBirth = x.DateOfBirth,
                Relationship = x.Relationship,
                PermanetAddress = x.PermanetAddress,
                TemporaryAddress = x.TemporaryAddress,
                Group = x.Group,
                Department = x.Department,
                WorkingAddress = x.WorkingAddress,
                Role = x.Role,
                StartingDate = x.StartingDate,
                Status = x.Status,
                WorkingPhone = x.WorkingPhone,
                Level = x.Level,
                LineManager = x.LineManager,
                LatestChangeDate = x.LatestChangeDate,
                ChangedModified = x.ChangedModified,
                ExpiredDate = x.ExpiredDate,
                Experience = x.Experience,
                Education = x.Education,
                CompanyAssets = x.CompanyAssets,
                LeavingReason = x.LeavingReason,
                Taxno = x.Taxno,
                SocialInsurantNumber = x.SocialInsurantNumber
            };
            if (x.LeavingAllowedNumber != null)
                itemViewModel.LeavingAllowedNumber = Convert.ToInt32(x.LeavingAllowedNumber);
            if (x.TicketsNumberIssued != null)
                itemViewModel.TicketsNumberIssued = Convert.ToInt32(x.TicketsNumberIssued);
            listItems.Add(itemViewModel);
        }

        public ApiResponse<string> InsertHr(List<HrInsertModels> data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<string>();
            var arrMessage = new List<string>();
            try
            {
                var hrRes = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListHr));
                foreach (var x in data)
                {
                    try
                    {
                        var newHr = new HrSpModels(hrRes, null)
                        {
                            EmployeeCode = x.EmployeeCode,
                            FullName = x.FullName,
                            CompanyEmail = x.CompanyEmail,
                            NickName = x.NickName,
                            PersonalPhone = x.PersonalPhone,
                            PersonalEmail = x.PersonalEmail,
                            DateOfBirth = x.DateOfBirth,
                            Relationship = x.Relationship,
                            PermanetAddress = x.PermanetAddress,
                            TemporaryAddress = x.TemporaryAddress,
                            Group = x.Group,
                            Department = x.Department,
                            WorkingAddress = x.WorkingAddress,
                            Role = x.Role,
                            StartingDate = x.StartingDate,
                            Status = x.Status,
                            WorkingPhone = x.WorkingPhone,
                            Level = x.Level,
                            LineManager = x.LineManager,
                            LatestChangeDate = x.LatestChangeDate,
                            ChangedModified = x.ChangedModified,
                            ExpiredDate = x.ExpiredDate,
                            Experience = x.Experience,
                            Education = x.Education,
                            CompanyAssets = x.CompanyAssets,
                            LeavingReason = x.LeavingReason,
                            LeavingAllowedNumber = x.LeavingAllowedNumber,
                            TicketsNumberIssued = x.TicketsNumberIssued,
                            Taxno = x.Taxno,
                            SocialInsurantNumber = x.SocialInsurantNumber
                        };
                        hrRes.AddOrUpdate(newHr);
                    }
                    catch (Exception e)
                    {
                        arrMessage.Add(e.Message);
                        apiResponse.ErrorType = 400;
                        apiResponse.ErrorMessage = arrMessage;
                    }
                }
                if (apiResponse.ErrorType != 400)
                    apiResponse.Content = new[] { Message.MessageApi.Success };
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

        public ApiResponse<string> UpdateHrByEmail(HrUpdateRequestModels data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<string>();
            var arrMessage = new List<string>();
            try
            {
                var hrRes = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListHr));
                var query = new CamlQuery { ViewXml = string.Format(HrView.GetHr.GetByCompanyEmail, data.Email) };
                var hrItemQuery = hrRes.Query(query, (item) => new HrSpModels(hrRes, item)).ToArray();
                if (hrItemQuery.Length == 0)
                {
                    apiResponse.ErrorMessage = new[] { Message.MessageApi.NoItem };
                    apiResponse.ErrorType = 400;
                    return apiResponse;
                }
                foreach (var itemQuery in hrItemQuery)
                {
                    itemQuery.EmployeeCode = data.HrModels.EmployeeCode;
                    itemQuery.FullName = data.HrModels.FullName;
                    itemQuery.CompanyEmail = data.HrModels.CompanyEmail;
                    itemQuery.NickName = data.HrModels.NickName;
                    itemQuery.PersonalPhone = data.HrModels.PersonalPhone;
                    itemQuery.PersonalEmail = data.HrModels.PersonalEmail;
                    itemQuery.DateOfBirth = data.HrModels.DateOfBirth;
                    itemQuery.Relationship = data.HrModels.Relationship;
                    itemQuery.PermanetAddress = data.HrModels.PermanetAddress;
                    itemQuery.TemporaryAddress = data.HrModels.TemporaryAddress;
                    itemQuery.Group = data.HrModels.Group;
                    itemQuery.Department = data.HrModels.Department;
                    itemQuery.WorkingAddress = data.HrModels.WorkingAddress;
                    itemQuery.Role = data.HrModels.Role;
                    itemQuery.StartingDate = data.HrModels.StartingDate;
                    itemQuery.Status = data.HrModels.Status;
                    itemQuery.WorkingPhone = data.HrModels.WorkingPhone;
                    itemQuery.Level = data.HrModels.Level;
                    itemQuery.LineManager = data.HrModels.LineManager;
                    itemQuery.LatestChangeDate = data.HrModels.LatestChangeDate;
                    itemQuery.ChangedModified = data.HrModels.ChangedModified;
                    itemQuery.ExpiredDate = data.HrModels.ExpiredDate;
                    itemQuery.Experience = data.HrModels.Experience;
                    itemQuery.Education = data.HrModels.Education;
                    itemQuery.CompanyAssets = data.HrModels.CompanyAssets;
                    itemQuery.LeavingReason = data.HrModels.LeavingReason;
                    itemQuery.Taxno = data.HrModels.Taxno;
                    itemQuery.SocialInsurantNumber = data.HrModels.SocialInsurantNumber;
                    itemQuery.LeavingAllowedNumber = data.HrModels.LeavingAllowedNumber;
                    itemQuery.TicketsNumberIssued = data.HrModels.TicketsNumberIssued;
                    hrRes.AddOrUpdate(itemQuery);
                }
                if (apiResponse.ErrorType != 400)
                    apiResponse.Content = new[] { Message.MessageApi.Success };
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

        public ApiResponse<HrViewModels> GetByEmail(string email, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<HrViewModels>();
            try
            {
                var listItems = new List<HrViewModels>();
                var hrRes = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListHr));
                var query = new CamlQuery { ViewXml = string.Format(HrView.GetHr.GetByCompanyEmail, email) };
                var hrItemQuery = hrRes.Query(query, (item) => new HrSpModels(hrRes, item)).ToArray();
                //.Where(x=>x.CompanyEmail==email).ToArray();
                if (hrItemQuery.Length == 0)
                {
                    apiResponse.ErrorMessage = new[] { Message.MessageApi.NoItem };
                    apiResponse.ErrorType = 400;
                    return apiResponse;
                }
                foreach (var itemQuery in hrItemQuery)
                {
                    GetItemModels(listItems, itemQuery, _clientContext);
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
    }
}
