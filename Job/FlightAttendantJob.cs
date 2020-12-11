using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirewayBE.API.Helper;
using BambooAirewayBE.API.Models.SPModels.FlightAttendant;
using BambooAirewayBE.API.Models.SPModels.FlightView;
using BambooAirewayBE.API.Models.ViewModels;
using BambooAirewayBE.API.Models.ViewModels.FlightAttendant;
using BambooAirewayBE.API.Models.ViewModels.FlightViewModels;
using BambooAirewayBE.API.Utilities.Constants;
using BambooAirewayBE.API.Utilities.ListConstant;
using BambooAirewayBE.API.Utilities.Utils.FlightAttendant;
using BambooAirewayBE.API.Utilities.Utils.FlightView;
using BambooAirwayBE.API.Data;
using BambooAirwayBE.API.Utilities.Utils;
using Microsoft.SharePoint.Client;
using WebGrease.Css.Extensions;

namespace BambooAirewayBE.API.Job
{
    public class FlightAttendantJob
    {
        private static ClientContext _clientContext;

        public FlightAttendantJob(ClientContext client)
        {
            _clientContext = client;
        }

        public ApiResponse<FlightAttendantProfileViewModels> GetAllProfile()
        {
            var apiResponse = new ApiResponse<FlightAttendantProfileViewModels>();
            try
            {
                var listAll = new List<FlightAttendantProfileViewModels>();
                var getAll = FlightAttendantUtils.GetFlightAttendantProfile(_clientContext);
                getAll?.ForEach(x =>
                {
                    var viewModels = new FlightAttendantProfileViewModels
                    {
                        Id = x.Id,
                        Title = x.Title,
                        FlightAttendantCode = x.FlightAttendantCode.LookupValue,
                        WorkingDate = x.WorkingDate,
                        FlightCode = x.FlightCode,
                        FlightDate = x.FlightDate,
                        FlightTimeUTC = x.FlightTimeUTC,
                        FlightTimeLocal = x.FlightTimeLocal,
                        Departure = x.Departure,
                        Destination = x.Destination,
                        DutyCode = x.DutyCode,
                        CrewId = x.CrewId,
                        EmployeeMission = x.EmployeeMission
                    };

                    listAll.Add(viewModels);
                });
                apiResponse.Content = listAll;
                return apiResponse;
            }
            catch (Exception e)
            {
                apiResponse.ErrorType = 400;
                apiResponse.ErrorMessage = new[] { e.Message };
                return apiResponse;
            }
        }

        public ApiResponse<string> InsertProfile(List<FlightAttendantProfileRequestViewModels> data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<string>();
            var arrMessage = new List<string>();
            try
            {
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListFlightAttendantProfile));
                foreach (var x in data)
                {
                    try
                    {
                        var newItem = new FlightAttendantProfileSpModels(res, null)
                        {
                            WorkingDate = x.WorkingDate,
                            FlightCode = x.FlightCode,
                            FlightDate = x.FlightDate,
                            FlightTimeUTC = x.FlightTimeUTC,
                            FlightTimeLocal = x.FlightTimeLocal,
                            Departure = x.Departure,
                            Destination = x.Destination,
                            DutyCode = x.DutyCode,
                            CrewId = x.CrewId,
                            EmployeeMission = x.EmployeeMission
                        };
                        newItem.FlightAttendantCode = new FieldLookupValue
                        {
                            LookupId = x.FlightAttendantCodeId
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

        public ApiResponse<FlightAttendantTitleViewModels> GetAllFlightAttendantTitle()
        {
            var apiResponse = new ApiResponse<FlightAttendantTitleViewModels>();
            try
            {
                var listAll = new List<FlightAttendantTitleViewModels>();
                var getAll = FlightAttendantUtils.GetFlightAttendantTitle(_clientContext);
                getAll?.ForEach(x =>
                {
                    var viewModels = new FlightAttendantTitleViewModels
                    {
                        Id = x.Id,
                        Title = x.Title,
                        EmployeeCode = x.EmployeeCode,
                        EmployeeName = x.EmployeeName,
                        PositionCode = x.PositionCode,
                        PositionName = x.PositionName,
                        EffectiveDate = x.EffectiveDate
                    };

                    listAll.Add(viewModels);
                });
                apiResponse.Content = listAll;
                return apiResponse;
            }
            catch (Exception e)
            {
                apiResponse.ErrorType = 400;
                apiResponse.ErrorMessage = new[] { e.Message };
                return apiResponse;
            }
        }

        public ApiResponse<string> InsertFlightAttendantTitle(List<FlightAttendantTitleRequestViewModels> data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<string>();
            var arrMessage = new List<string>();
            try
            {
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListFlightAttendantTitle));
                foreach (var x in data)
                {
                    try
                    {
                        var newItem = new FlightAttendantTitleSpModels(res, null)
                        {
                            EmployeeCode = x.EmployeeCode,
                            EmployeeName = x.EmployeeName,
                            PositionCode = x.PositionCode,
                            PositionName = x.PositionName,
                            EffectiveDate = x.EffectiveDate
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

        public ApiResponse<ReviewCategoryViewModels> GetAllReviewCategory()
        {
            var apiResponse = new ApiResponse<ReviewCategoryViewModels>();
            try
            {
                var listAll = new List<ReviewCategoryViewModels>();
                var getAll = FlightAttendantUtils.GetReviewCategory(_clientContext);
                getAll?.ForEach(x =>
                {
                    var viewModels = new ReviewCategoryViewModels
                    {
                        Id = x.Id,
                        Phase = x.Phase,
                        EvaluationCriteria = x.EvaluationCriteria,
                        Satisfy = x.Satisfy,
                        NotSatisfy = x.NotSatisfy,
                        NeedImprove = x.NeedImprove,
                        Detail = x.Detail,
                        EffectiveDate = x.EffectiveDate,
                        EffectiveToDate = x.EffectiveToDate


                    };
                    if (x.ReviewCategoryId != null)
                        viewModels.ReviewCategoryId = new LookupModels
                        {
                            LookupId = x.ReviewCategoryId.LookupId,
                            LookupValue = x.ReviewCategoryId.LookupValue
                        };
                    if (x.CreatedUser != null)
                        viewModels.CreatedUser = new LookupModels
                        {
                            LookupValue = x.CreatedUser.LookupValue,
                            LookupId = x.CreatedUser.LookupId
                        };
                    if (x.BeReviewedUser != null)
                        viewModels.BeReviewedUser = new LookupModels
                        {
                            LookupId = x.BeReviewedUser.LookupId,
                            LookupValue = x.BeReviewedUser.LookupValue
                        };
                    listAll.Add(viewModels);
                });
                apiResponse.Content = listAll;
                return apiResponse;
            }
            catch (Exception e)
            {
                apiResponse.ErrorType = 400;
                apiResponse.ErrorMessage = new[] { e.Message };
                return apiResponse;
            }
        }

        public ApiResponse<string> InsertReviewCategory(List<ReviewCategoryRequestViewModels> data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<string>();
            var arrMessage = new List<string>();
            try
            {
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListReviewCategory));
                foreach (var x in data)
                {
                    try
                    {
                        var newItem = new ReviewCategorySpModels(res, null)
                        {
                            Phase = x.Phase,
                            EvaluationCriteria = x.EvaluationCriteria,
                            Satisfy = x.Satisfy,
                            NotSatisfy = x.NotSatisfy,
                            NeedImprove = x.NeedImprove,
                            Detail = x.Detail,
                            EffectiveDate = x.EffectiveDate,
                            EffectiveToDate = x.EffectiveToDate,
                            Status = x.Status
                        };
                        if (x.ReviewCategoryId != null)
                            newItem.ReviewCategoryId = new FieldLookupValue
                            {
                                LookupId = x.ReviewCategoryId.LookupId
                            };
                        if (x.CreatedUser != null)
                            newItem.CreatedUser = new FieldLookupValue
                            {
                                LookupId = x.CreatedUser.LookupId
                            };
                        if (x.BeReviewedUser != null)
                            newItem.BeReviewedUser = new FieldLookupValue
                            {
                                LookupId = x.BeReviewedUser.LookupId
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

        public ApiResponse<TitleTemplateViewModels> GetAllTitleTemplate()
        {
            var apiResponse = new ApiResponse<TitleTemplateViewModels>();
            try
            {
                var listAll = new List<TitleTemplateViewModels>();
                var getAll = FlightAttendantUtils.GetTitleTemplate(_clientContext);
                getAll?.ForEach(x =>
                {
                    var viewModels = new TitleTemplateViewModels
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Code = x.Code
                    };
                    listAll.Add(viewModels);
                });
                apiResponse.Content = listAll;
                return apiResponse;
            }
            catch (Exception e)
            {
                apiResponse.ErrorType = 400;
                apiResponse.ErrorMessage = new[] { e.Message };
                return apiResponse;
            }
        }

        public ApiResponse<string> InsertTitleTemplate(List<TitleTemplateRequestViewModels> data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<string>();
            var arrMessage = new List<string>();
            try
            {
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListTitleTemplate));
                foreach (var x in data)
                {
                    try
                    {
                        var newItem = new TitleTemplateSpModels(res, null)
                        {
                            Title = x.Title,
                            Code = x.Code,
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

        public ApiResponse<ResultDetailFlightAttendantViewModels> GetAllResultDetailFlightAttendant()
        {
            var apiResponse = new ApiResponse<ResultDetailFlightAttendantViewModels>();
            try
            {
                var listAll = new List<ResultDetailFlightAttendantViewModels>();
                var getAll = FlightAttendantUtils.GetResultDetailFlightAttendant(_clientContext);
                getAll?.ForEach(x =>
                {
                    var viewModels = new ResultDetailFlightAttendantViewModels
                    {
                        Id = x.Id,
                        Result=x.Result,
                        Avarage=x.Avarage,
                        Note=x.Note,
                        Deadline=x.Deadline,
                    };
                    if (x.EmployeeCode != null)
                        viewModels.EmployeeCode = new LookupModels
                        {
                            LookupId = x.EmployeeCode.LookupId,
                            LookupValue = x.EmployeeCode.LookupValue
                        };
                    if (x.Assessor != null)
                        viewModels.Assessor = new LookupModels
                        {
                            LookupId = x.Assessor.LookupId,
                            LookupValue = x.Assessor.LookupValue
                        };
                    listAll.Add(viewModels);
                });
                apiResponse.Content = listAll;
                return apiResponse;
            }
            catch (Exception e)
            {
                apiResponse.ErrorType = 400;
                apiResponse.ErrorMessage = new[] { e.Message };
                return apiResponse;
            }
        }

        public ApiResponse<string> InsertResultDetailFlightAttendant(List<ResultDetailFlightAttendantRequestViewModels> data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<string>();
            var arrMessage = new List<string>();
            try
            {
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListResultDetailFlightAttendant));
                foreach (var x in data)
                {
                    try
                    {
                        var newItem = new ResultDetailFlightAttendantSpModels(res, null)
                        {
                            Result=x.Result,
                            Avarage  =x.Avarage,
                            Note     = x.Note,
                            Deadline =x.Deadline
                        };
                        if (x.EmployeeCode != null)
                            newItem.EmployeeCode = new FieldLookupValue
                            {
                                LookupId = x.EmployeeCode.LookupId
                            };
                        if (x.Assessor != null)
                            newItem.Assessor = new FieldLookupValue
                            {
                                LookupId = x.Assessor.LookupId
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

        public ApiResponse<ResultFlightViewModels> GetAllResultFlight()
        {
            var apiResponse = new ApiResponse<ResultFlightViewModels>();
            try
            {
                var listAll = new List<ResultFlightViewModels>();
                var getAll = FlightAttendantUtils.GetResultFlight(_clientContext);
                getAll?.ForEach(x =>
                {
                    var viewModels = new ResultFlightViewModels
                    {
                        Id = x.Id,
                        IdentifyName = x.IdentifyName,
                        FullName = x.FullName,
                        PositonName = x.PositonName,
                        Result = x.Result,
                        Avarage = x.Avarage,
                        Note = x.Note,
                    };
                    if (x.StaffId != null)
                        viewModels.StaffId = new LookupModels
                        {
                            LookupId = x.StaffId.LookupId,
                            LookupValue = x.StaffId.LookupValue
                        };
                    if (x.Creator != null)
                        viewModels.Creator = new LookupModels
                        {
                            LookupId = x.Creator.LookupId,
                            LookupValue = x.Creator.LookupValue
                        };
                    listAll.Add(viewModels);
                });
                apiResponse.Content = listAll;
                return apiResponse;
            }
            catch (Exception e)
            {
                apiResponse.ErrorType = 400;
                apiResponse.ErrorMessage = new[] { e.Message };
                return apiResponse;
            }
        }

        public ApiResponse<string> InsertResultFlight(List<ResultFlightRequestViewModels> data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<string>();
            var arrMessage = new List<string>();
            try
            {
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListResultFlight));
                foreach (var x in data)
                {
                    try
                    {
                        var newItem = new ResultFlightSpModels(res, null)
                        {
                            IdentifyName = x.IdentifyName,
                            FullName = x.FullName,
                            PositonName = x.PositonName,
                            Result = x.Result,
                            Avarage = x.Avarage,
                            Note = x.Note,
                        };
                        if (x.StaffId != null)
                            newItem.StaffId = new FieldLookupValue
                            {
                                LookupId = x.StaffId.LookupId,
                            };
                        if (x.Creator != null)
                            newItem.Creator = new FieldLookupValue
                            {
                                LookupId = x.Creator.LookupId,
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
    }
}