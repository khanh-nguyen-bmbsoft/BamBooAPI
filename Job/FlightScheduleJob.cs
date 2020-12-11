using BambooAirewayBE.API.Helper;
using BambooAirewayBE.API.Models.SPModels.FlightView;
using BambooAirewayBE.API.Models.ViewModels.FlightViewModels;
using BambooAirewayBE.API.Utilities.Constants;
using BambooAirewayBE.API.Utilities.ListConstant;
using BambooAirewayBE.API.Utilities.Utils.FlightView;
using BambooAirwayBE.API.Data;
using BambooAirwayBE.API.Utilities.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BambooAirewayBE.API.Models.ViewModels;
using WebGrease.Css.Extensions;
using BambooAirewayBE.API.Utilities.CalmQuery;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Job
{
    public class FlightScheduleJob
    {
        private static ClientContext _clientContext;

        public FlightScheduleJob(ClientContext client)
        {
            _clientContext = client;
        }

        #region Flight Schedules
        public ApiResponse<FlightScheduleViewModels> GetAllFlightSchedules()
        {
            var apiResponse = new ApiResponse<FlightScheduleViewModels>();
            try
            {
                var listAll = new List<FlightScheduleViewModels>();
                var getAll = FlightViewUtils.GetFlightSchedule(_clientContext);
                getAll?.ForEach(x =>
                {
                    var viewModels = new FlightScheduleViewModels
                    {
                        Id = x.Id,
                        FlightCreatedAt = x.FlightCreatedAt,
                        FlightUpdatedAt = x.FlightUpdatedAt,
                        AircraftId = x.AircraftId,
                        FlightDateGMT0 = x.FlightDateGMT0,
                        FlightDateGMT5 = x.FlightDateGMT5,
                        FlightDateGMT7 = x.FlightDateGMT7,
                        FlightDate = x.FlightDate,
                        FlightNumber = x.FlightNumber,
                        Status = x.Status,
                        DepartureDate = x.DepartureDate,
                        DepartureDateGMT0 = x.DepartureDateGMT0,
                        DepartureDateGmt7 = x.DepartureDateGmt7,
                        DepartureGate = x.DepartureGate,
                        BoardingStatus = x.BoardingStatus,
                        BoardingTime = x.BoardingTime,
                        FlightEtd = x.FlightEtd,
                        FlightEtdGmt0 = x.FlightEtdGmt0,
                        FlightEtdGmt7 = x.FlightEtdGmt7,
                        FlightStd = x.FlightStd,
                        FlightStdGmt0 = x.FlightStdGmt0,
                        FlightStdGmt7 = x.FlightStdGmt7,
                        FlightEta = x.FlightEta,
                        FlightEtaGmt0 = x.FlightEtaGmt0,
                        FlightEtaGmt7 = x.FlightEtaGmt7,
                        FlightSta = x.FlightSta,
                        FlightStaGmt0 = x.FlightStaGmt0,
                        FlightStaGmt7 = x.FlightStaGmt7,
                        Origin = x.Origin,
                        Destination = x.Destination,
                        Route = x.Route,
                        FlightReg = x.FlightReg,
                        FlightAcType = x.FlightAcType
                    };
                    if (x.FlightId != null)
                        viewModels.FlightId = Convert.ToInt32(x.FlightId);

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

        public ApiResponse<string> InsertFlightSchedules(List<FlightScheduleRequestViewModels> data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<string>();
            var arrMessage = new List<string>();
            try
            {
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListFlightSchedule));
                foreach (var x in data)
                {
                    try
                    {
                        var newItem = new FlightScheduleSpModels(res, null)
                        {
                            FlightCreatedAt = x.FlightCreatedAt,
                            FlightUpdatedAt = x.FlightUpdatedAt,
                            AircraftId = x.AircraftId,
                            FlightDateGMT0 = x.FlightDateGMT0,
                            FlightDateGMT5 = x.FlightDateGMT5,
                            FlightDateGMT7 = x.FlightDateGMT7,
                            FlightDate = x.FlightDate,
                            FlightNumber = x.FlightNumber,
                            Status = x.Status,
                            DepartureDate = x.DepartureDate,
                            DepartureDateGMT0 = x.DepartureDateGMT0,
                            DepartureDateGmt7 = x.DepartureDateGmt7,
                            DepartureGate = x.DepartureGate,
                            BoardingStatus = x.BoardingStatus,
                            BoardingTime = x.BoardingTime,
                            FlightEtd = x.FlightEtd,
                            FlightEtdGmt0 = x.FlightEtdGmt0,
                            FlightEtdGmt7 = x.FlightEtdGmt7,
                            FlightStd = x.FlightStd,
                            FlightStdGmt0 = x.FlightStdGmt0,
                            FlightStdGmt7 = x.FlightStdGmt7,
                            FlightEta = x.FlightEta,
                            FlightEtaGmt0 = x.FlightEtaGmt0,
                            FlightEtaGmt7 = x.FlightEtaGmt7,
                            FlightSta = x.FlightSta,
                            FlightStaGmt0 = x.FlightStaGmt0,
                            FlightStaGmt7 = x.FlightStaGmt7,
                            Origin = x.Origin,
                            Destination = x.Destination,
                            Route = x.Route,
                            FlightReg = x.FlightReg,
                            FlightAcType = x.FlightAcType
                        };
                        if (x.FlightId > 0)
                            newItem.FlightId = x.FlightId.ToString();
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

        public ApiResponse<FlightScheduleViewModels> GetByFlightDate(GetByFlightDateRequest data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<FlightScheduleViewModels>();
            try
            {
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListFlightSchedule));
                var listAll = new List<FlightScheduleViewModels>();
                var query = new CamlQuery { ViewXml = string.Format(FlightView.FlightSchedules.GetByFlightDate, data.FlightDate.ToString("yyyy-MM-ddTHH:mm:ssZ")) };
                var filghtDate = res.Query(query, (item) => new FlightScheduleSpModels(res, item)).ToArray();
        
                if (filghtDate.Length == 0)
                {
                    apiResponse.ErrorType = 400;
                    apiResponse.ErrorMessage = new List<string> { Message.MessageApi.NoItem };
                    return apiResponse;
                }
                filghtDate.ForEach(x =>
                {
                    var viewModels = new FlightScheduleViewModels
                    {
                        Id = x.Id,
                        FlightCreatedAt = x.FlightCreatedAt,
                        FlightUpdatedAt = x.FlightUpdatedAt,
                        AircraftId = x.AircraftId,
                        FlightDateGMT0 = x.FlightDateGMT0,
                        FlightDateGMT5 = x.FlightDateGMT5,
                        FlightDateGMT7 = x.FlightDateGMT7,
                        FlightDate = x.FlightDate,
                        FlightNumber = x.FlightNumber,
                        Status = x.Status,
                        DepartureDate = x.DepartureDate,
                        DepartureDateGMT0 = x.DepartureDateGMT0,
                        DepartureDateGmt7 = x.DepartureDateGmt7,
                        DepartureGate = x.DepartureGate,
                        BoardingStatus = x.BoardingStatus,
                        BoardingTime = x.BoardingTime,
                        FlightEtd = x.FlightEtd,
                        FlightEtdGmt0 = x.FlightEtdGmt0,
                        FlightEtdGmt7 = x.FlightEtdGmt7,
                        FlightStd = x.FlightStd,
                        FlightStdGmt0 = x.FlightStdGmt0,
                        FlightStdGmt7 = x.FlightStdGmt7,
                        FlightEta = x.FlightEta,
                        FlightEtaGmt0 = x.FlightEtaGmt0,
                        FlightEtaGmt7 = x.FlightEtaGmt7,
                        FlightSta = x.FlightSta,
                        FlightStaGmt0 = x.FlightStaGmt0,
                        FlightStaGmt7 = x.FlightStaGmt7,
                        Origin = x.Origin,
                        Destination = x.Destination,
                        Route = x.Route,
                        FlightReg = x.FlightReg,
                        FlightAcType = x.FlightAcType
                    };
                    if (x.FlightId != null)
                        viewModels.FlightId = Convert.ToInt32(x.FlightId);

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

        public ApiResponse<FlightScheduleViewModels> GetFlDateAndFlNumber(GetByFlightDateAndFlightNumberRequest data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<FlightScheduleViewModels>();
            try
            {
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListFlightSchedule));
                var listAll = new List<FlightScheduleViewModels>();
                var query = new CamlQuery { ViewXml = string.Format(FlightView.FlightSchedules.GetByFlightDateAndFlightNumber, data.FlightDate.ToString("yyyy-MM-ddTHH:mm:ssZ"), data.FlightNumber) };
                var filghtDate = res.Query(query, (item) => new FlightScheduleSpModels(res, item)).ToArray();
                    //.Where(x => x.FlightDate != null && x.FlightNumber != null && x.FlightDate.Value == data.FlightDate.Date && int.Parse(x.FlightNumber) == int.Parse(data.FlightNumber)).ToArray();
                if (filghtDate.Length == 0)
                {
                    apiResponse.ErrorType = 400;
                    apiResponse.ErrorMessage = new List<string> { Message.MessageApi.NoItem };
                    return apiResponse;
                }
                filghtDate.ForEach(x =>
                {
                    var viewModels = new FlightScheduleViewModels
                    {
                        Id = x.Id,
                        FlightCreatedAt = x.FlightCreatedAt,
                        FlightUpdatedAt = x.FlightUpdatedAt,
                        AircraftId = x.AircraftId,
                        FlightDateGMT0 = x.FlightDateGMT0,
                        FlightDateGMT5 = x.FlightDateGMT5,
                        FlightDateGMT7 = x.FlightDateGMT7,
                        FlightDate = x.FlightDate,
                        FlightNumber = x.FlightNumber,
                        Status = x.Status,
                        DepartureDate = x.DepartureDate,
                        DepartureDateGMT0 = x.DepartureDateGMT0,
                        DepartureDateGmt7 = x.DepartureDateGmt7,
                        DepartureGate = x.DepartureGate,
                        BoardingStatus = x.BoardingStatus,
                        BoardingTime = x.BoardingTime,
                        FlightEtd = x.FlightEtd,
                        FlightEtdGmt0 = x.FlightEtdGmt0,
                        FlightEtdGmt7 = x.FlightEtdGmt7,
                        FlightStd = x.FlightStd,
                        FlightStdGmt0 = x.FlightStdGmt0,
                        FlightStdGmt7 = x.FlightStdGmt7,
                        FlightEta = x.FlightEta,
                        FlightEtaGmt0 = x.FlightEtaGmt0,
                        FlightEtaGmt7 = x.FlightEtaGmt7,
                        FlightSta = x.FlightSta,
                        FlightStaGmt0 = x.FlightStaGmt0,
                        FlightStaGmt7 = x.FlightStaGmt7,
                        Origin = x.Origin,
                        Destination = x.Destination,
                        Route = x.Route,
                        FlightReg = x.FlightReg,
                        FlightAcType = x.FlightAcType
                    };
                    if (x.FlightId != null)
                        viewModels.FlightId = Convert.ToInt32(x.FlightId);

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
        #endregion

        #region Flight Member
        public ApiResponse<FlightMemberViewModels> GetAllFlightMembers()
        {
            var apiResponse = new ApiResponse<FlightMemberViewModels>();
            try
            {
                var allFlightView = from flightView in FlightViewUtils.GetFlightMembers(_clientContext)
                                    let flightViewFlightId = flightView.FlightId
                                    where flightViewFlightId != null
                                    select new FlightMemberViewModels
                                    {
                                        Id = flightView.Id,
                                        FlightId = flightView.FlightId.Value,
                                        FlightCreatedAt = flightView.FlightCreatedAt,
                                        FlightUpdatedAt = flightView.FlightUpdatedAt,
                                        Pilot = flightView.Pilot,
                                        Attendant = flightView.Attendant,
                                        FlightNumber = Convert.ToInt32(flightView.FlightNumber),
                                        FlightDate = flightView.FlightDate,
                                        FlightScheduleId = new LookupModels { LookupId = flightView.FlightScheduleId.LookupId, LookupValue = flightView.FlightScheduleId.LookupValue }
                                    };
                apiResponse.Content = allFlightView;
                return apiResponse;
            }
            catch (Exception e)
            {
                apiResponse.ErrorType = 400;
                apiResponse.ErrorMessage = new[] { e.Message };
                return apiResponse;
            }
        }

        public ApiResponse<FlightMemberViewModels> GetByFlightDateFlightMembers(GetFlDateAndFlNumberMemberModels data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<FlightMemberViewModels>();
            try
            {
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListFlightMembers));
                var listAll = new List<FlightMemberViewModels>();
                var query = new CamlQuery { ViewXml = string.Format(FlightView.FlightSchedules.GetByFlightDate, data.FlightDate.ToString("yyyy-MM-ddTHH:mm:ssZ")) };
                var filghtDate = res.Query(query, (item) => new FlightMemberSpModels(res, item)).ToArray();
                    //.Where(x => x.FlightDate != null && x.FlightDate.Date == data.FlightDate.Date).ToArray();
                if (filghtDate.Length == 0)
                {
                    apiResponse.ErrorType = 400;
                    apiResponse.ErrorMessage = new List<string> { Message.MessageApi.NoItem };
                    return apiResponse;
                }
                filghtDate.ForEach(x =>
                {
                    var viewModels = new FlightMemberViewModels
                    {
                        Id = x.Id,
                        FlightCreatedAt = x.FlightCreatedAt,
                        FlightUpdatedAt = x.FlightUpdatedAt,
                        Pilot = x.Pilot,
                        Attendant = x.Attendant,
                        FlightNumber = x.FlightNumber,
                        FlightDate = x.FlightDate
                    };
                    if (x.FlightId != null)
                    {
                        viewModels.FlightId = x.FlightId.Value;
                        viewModels.Title = x.Title;
                    }

                    if (x.FlightScheduleId != null)
                        viewModels.FlightScheduleId = new LookupModels
                        {
                            LookupId = x.FlightScheduleId.LookupId,
                            LookupValue = x.FlightScheduleId.LookupValue
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

        public ApiResponse<string> InsertFlightMembers(List<FlightMemberRequestViewModels> data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<string>();
            var arrMessage = new List<string>();
            try
            {
                var listFlightSchedule = FlightViewUtils.GetFlightSchedule(_clientContext);
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListFlightMembers));
                foreach (var x in data)
                {
                    try
                    {
                        if (x.FlightNumber <= 0 || !x.FlightDate.HasValue)
                        {
                            arrMessage.Add("Missing FlightNumber or FlightDate at " + x.FlightId);
                            apiResponse.ErrorType = 400;
                            continue;
                        }

                        var flightSchedule = listFlightSchedule.FirstOrDefault(flSchedule =>
                            flSchedule.FlightNumber != null && flSchedule.FlightDate != null
                                                            && Convert.ToInt32(flSchedule.FlightNumber) == x.FlightNumber
                                                            && flSchedule.FlightDate.Value == x.FlightDate.Value);
                        if (flightSchedule == null)
                        {
                            arrMessage.Add(" FlightNumber or FlightDate not match at " + x.FlightId);
                            apiResponse.ErrorType = 400;
                            continue;
                        }


                        var newItem = new FlightMemberSpModels(res, null)
                        {
                            Title = x.FlightId.ToString(),
                            FlightId = x.FlightId,
                            FlightScheduleId = new FieldLookupValue { LookupId = flightSchedule.Id },
                            FlightCreatedAt = x.FlightCreatedAt,
                            FlightUpdatedAt = x.FlightUpdatedAt,
                            Pilot = x.Pilot,
                            Attendant = x.Attendant,
                            FlightNumber = x.FlightNumber,
                        };
                        if (x.FlightDate.HasValue)
                            newItem.FlightDate = x.FlightDate.Value;

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
        #endregion

        #region Flight Passenger

        public ApiResponse<FlightPassengerViewModels> GetAllFlightPassengers()
        {
            var apiResponse = new ApiResponse<FlightPassengerViewModels>();
            try
            {
                var listAll = new List<FlightPassengerViewModels>();
                var getAll = FlightViewUtils.GetFlightPassengers(_clientContext);
                getAll?.ForEach(x =>
                {
                    var viewModels = new FlightPassengerViewModels
                    {
                        Id = x.Id,
                        FlightId = x.FlightId,
                        FlightCreatedAt = x.FlightCreatedAt,
                        FlightUpdatedAt = x.FlightUpdatedAt,
                        Economy = x.Economy,
                        Business = x.Business,
                        EconomySsrCode = x.EconomySsrCode,
                        BusinessSsrCode = x.BusinessSsrCode,
                        FlightNumber = x.FlightNumber,
                        FlightDate = x.FlightDate
                    };
                    if (x.FlightScheduleId != null)
                        viewModels.FlightScheduleId = new LookupModels
                        {
                            LookupId = x.FlightScheduleId.LookupId,
                            LookupValue = x.FlightScheduleId.LookupValue
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

        public ApiResponse<FlightPassengerViewModels> GetByFlDateAndFlNumberPassenger(FlightPassengerGetflDateAndflNumber data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<FlightPassengerViewModels>();
            try
            {
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListFlightPassengers));
                var listAll = new List<FlightPassengerViewModels>();
                var query = new CamlQuery { ViewXml = string.Format(FlightView.FlightMembers.GetByFlightDateAndFlightNumberPassenger, data.FlightDate.ToString("yyyy-MM-ddTHH:mm:ssZ"), data.FlightNumber) };
                var filghtDate = res.Query(query, (item) => new FlightPassengerSpModels(res, item)).ToArray();
           //.Where(x => x.FlightDate.HasValue && x.FlightNumber.HasValue && x.FlightDate.Value.Date == data.FlightDate.Date && x.FlightNumber.Value == data.FlightNumber).ToArray();
                if (filghtDate.Length == 0)
                {
                    apiResponse.ErrorType = 400;
                    apiResponse.ErrorMessage = new List<string> { Message.MessageApi.NoItem };
                    return apiResponse;
                }
                filghtDate.ForEach(x =>
                {
                    var viewModels = new FlightPassengerViewModels
                    {
                        Id = x.Id,
                        FlightId = x.FlightId,
                        FlightCreatedAt = x.FlightCreatedAt,
                        FlightUpdatedAt = x.FlightUpdatedAt,
                        Economy = x.Economy,
                        Business = x.Business,
                        EconomySsrCode = x.EconomySsrCode,
                        BusinessSsrCode = x.BusinessSsrCode,
                        FlightNumber = x.FlightNumber,
                        FlightDate = x.FlightDate
                    };
                    if (x.FlightScheduleId != null)
                        viewModels.FlightScheduleId = new LookupModels
                        {
                            LookupId = x.FlightScheduleId.LookupId,
                            LookupValue = x.FlightScheduleId.LookupValue
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

        public ApiResponse<string> InsertFlightPassengers(List<FlightPassengerRequestViewModels> data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<string>();
            var arrMessage = new List<string>();
            try
            {
                var listFlightSchedule = FlightViewUtils.GetFlightSchedule(_clientContext);
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListFlightPassengers));
                foreach (var flight in data)
                {
                    try
                    {
                        if (!flight.FlightNumber.HasValue || !flight.FlightDate.HasValue)
                        {
                            arrMessage.Add("Missing FlightNumber or FlightDate at " + flight.FlightId);
                            apiResponse.ErrorType = 400;
                            continue;
                        }
                        var flightSchedule = listFlightSchedule.FirstOrDefault(x =>
                            flight.FlightNumber != null && flight.FlightDate != null && int.Parse(x.FlightNumber) == flight.FlightNumber.Value && x.FlightDate.HasValue && flight.FlightDate.Value == x.FlightDate.Value);
                        if (flightSchedule == null)
                        {
                            arrMessage.Add(" FlightNumber or FlightDate not match at " + flight.FlightId);
                            apiResponse.ErrorType = 400;
                            continue;
                        }
                        var newItem = new FlightPassengerSpModels(res, null)
                        {
                            FlightId = flight.FlightId,
                            Title = flight.FlightId.ToString(),
                            FlightCreatedAt = flight.FlightCreatedAt,
                            FlightUpdatedAt = flight.FlightUpdatedAt,
                            Economy = flight.Economy,
                            Business = flight.Business,
                            EconomySsrCode = flight.EconomySsrCode,
                            BusinessSsrCode = flight.BusinessSsrCode,
                            FlightNumber = flight.FlightNumber,
                            FlightDate = flight.FlightDate,
                            FlightScheduleId = new FieldLookupValue
                            {
                                LookupId = flightSchedule.Id
                            }
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
        #endregion

        #region Flight Crew
        public ApiResponse<FlightCrewViewModels> GetAllFlightCrews()
        {
            var apiResponse = new ApiResponse<FlightCrewViewModels>();
            try
            {
                var listAll = new List<FlightCrewViewModels>();
                var getAll = FlightViewUtils.GetFlightCrews(_clientContext);
                getAll?.ForEach(x =>
                {
                    var viewModels = new FlightCrewViewModels
                    {
                        Id = x.Id,
                        FlightCrewCreatedAt = x.FlightCrewCreatedAt,
                        FlightCrewUpdatedAt = x.FlightCrewUpdatedAt,
                        AimsId = x.AimsId,
                        Name = x.Name,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        ShortName = x.ShortName,
                        Location = x.Location,
                        Quals = x.Quals,
                        Sex = x.Sex,
                        Marital = x.Marital,
                        NationalityCode = x.NationalityCode,
                        Nationality = x.Nationality,
                        ZipCode = x.ZipCode,
                        City = x.City,
                        State = x.State,
                        ContactCell = x.ContactCell,
                        ContactTel = x.ContactTel,
                        Email = x.Email,
                        NextKinName = x.NextKinName,
                        NextKinRelsn = x.NextKinRelsn,
                        NextKinContact = x.NextKinContact,
                        UserId = x.UserId,
                        Address = x.Address,
                        EmploymentDate = x.EmploymentDate,
                        Language = x.Language,
                        Language2 = x.Language2,
                        LicenceNum = x.LicenceNum,
                        CrewId = x.CrewId,
                        Position = x.Position,
                        Ac = x.Ac,
                        FlightNumber = x.FlightNumber,
                        FlightDate = x.FlightDate
                    };
                    if (!string.IsNullOrEmpty(x.FlightCrewId))
                        viewModels.FlightCrewId = Convert.ToInt32(x.FlightCrewId);

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

        public ApiResponse<string> InsertFlightCrews(List<FlightCrewRequestViewModels> data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<string>();
            var arrMessage = new List<string>();
            try
            {
                var listFlightSchedule = FlightViewUtils.GetFlightSchedule(_clientContext);
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListFlightCrews));
                foreach (var flight in data)
                {
                    try
                    {
                        if (!flight.FlightNumber.HasValue || !flight.FlightDate.HasValue)
                        {
                            arrMessage.Add("Missing FlightNumber or FlightDate at " + flight.FlightCrewId);
                            apiResponse.ErrorType = 400;
                            continue;
                        }
                        var flightSchedule = listFlightSchedule.FirstOrDefault(x =>
                            flight.FlightNumber != null && flight.FlightDate != null && int.Parse(x.FlightNumber) == flight.FlightNumber.Value && x.FlightDate.HasValue && flight.FlightDate.Value == x.FlightDate.Value);
                        if (flightSchedule == null)
                        {
                            arrMessage.Add(" FlightNumber or FlightDate not match at " + flight.FlightCrewId);
                            apiResponse.ErrorType = 400;
                            continue;
                        }
                        var newItem = new FlightCrewSpModels(res, null)
                        {
                            FlightCrewCreatedAt = flight.FlightCrewCreatedAt,
                            FlightCrewUpdatedAt = flight.FlightCrewUpdatedAt,
                            AimsId = flight.AimsId,
                            Name = flight.Name,
                            FirstName = flight.FirstName,
                            LastName = flight.LastName,
                            ShortName = flight.ShortName,
                            Location = flight.Location,
                            Quals = flight.Quals,
                            Sex = flight.Sex,
                            Marital = flight.Marital,
                            NationalityCode = flight.NationalityCode,
                            Nationality = flight.Nationality,
                            ZipCode = flight.ZipCode,
                            City = flight.City,
                            State = flight.State,
                            ContactCell = flight.ContactCell,
                            ContactTel = flight.ContactTel,
                            Email = flight.Email,
                            NextKinName = flight.NextKinName,
                            NextKinRelsn = flight.NextKinRelsn,
                            NextKinContact = flight.NextKinContact,
                            UserId = flight.UserId,
                            Address = flight.Address,
                            EmploymentDate = flight.EmploymentDate,
                            Language = flight.Language,
                            Language2 = flight.Language2,
                            LicenceNum = flight.LicenceNum,
                            CrewId = flight.CrewId,
                            Position = flight.Position,
                            Ac = flight.Ac,
                            FlightNumber = flight.FlightNumber,
                            FlightDate = flight.FlightDate,
                            FlightScheduleId = new FieldLookupValue
                            {
                                LookupId = flightSchedule.Id
                            }
                        };
                        if (flight.FlightCrewId > 0)
                            newItem.FlightCrewId = flight.FlightCrewId.ToString();
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

        public ApiResponse<FlightCrewViewModels> GetCrewflDateAndflNumber(GetFlDateAndFlNumberMemberModels data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<FlightCrewViewModels>();
            try
            {
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.ListFlightCrews));
                var listAll = new List<FlightCrewViewModels>();
                var query = new CamlQuery { ViewXml = string.Format(FlightView.FlightMembers.GetByFlightDateAndFlightNumberPassenger, data.FlightDate.ToString("yyyy-MM-ddTHH:mm:ssZ"), data.FlightNumber) };
                var filghtDate = res.Query(query, (item) => new FlightCrewSpModels(res, item)).ToArray();
                    //.Where(item => item.FlightNumber != null && item.FlightDate != null && item.FlightDate.Value == data.FlightDate && item.FlightNumber.Value == data.FlightNumber).ToArray();
                if (filghtDate.Length == 0)
                {
                    apiResponse.ErrorType = 400;
                    apiResponse.ErrorMessage = new List<string> { Message.MessageApi.NoItem };
                    return apiResponse;
                }
                filghtDate.ForEach(x =>
                {
                    var viewModels = new FlightCrewViewModels
                    {
                        Id = x.Id,
                        FlightCrewCreatedAt = x.FlightCrewCreatedAt,
                        FlightCrewUpdatedAt = x.FlightCrewUpdatedAt,
                        AimsId = x.AimsId,
                        Name = x.Name,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        ShortName = x.ShortName,
                        Location = x.Location,
                        Quals = x.Quals,
                        Sex = x.Sex,
                        Marital = x.Marital,
                        NationalityCode = x.NationalityCode,
                        Nationality = x.Nationality,
                        ZipCode = x.ZipCode,
                        City = x.City,
                        State = x.State,
                        ContactCell = x.ContactCell,
                        ContactTel = x.ContactTel,
                        Email = x.Email,
                        NextKinName = x.NextKinName,
                        NextKinRelsn = x.NextKinRelsn,
                        NextKinContact = x.NextKinContact,
                        UserId = x.UserId,
                        Address = x.Address,
                        EmploymentDate = x.EmploymentDate,
                        Language = x.Language,
                        Language2 = x.Language2,
                        LicenceNum = x.LicenceNum,
                        CrewId = x.CrewId,
                        Position = x.Position,
                        Ac = x.Ac,
                        FlightNumber = x.FlightNumber,
                        FlightDate = x.FlightDate
                    };
                    if (!string.IsNullOrEmpty(x.FlightCrewId))
                        viewModels.FlightCrewId = Convert.ToInt32(x.FlightCrewId);
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
        #endregion

        #region FlightPassengerDetail
        public ApiResponse<FlightPassengerDetailViewModels> GetAllFlightPassengerDetail()
        {
            var apiResponse = new ApiResponse<FlightPassengerDetailViewModels>();
            try
            {
                var listAll = new List<FlightPassengerDetailViewModels>();
                var getAll = FlightViewUtils.GetFlightPassengerDetail(_clientContext);
                getAll?.ForEach(x =>
                {
                    var viewModels = new FlightPassengerDetailViewModels
                    {
                        Id = x.Id,
                        FlightPassengerDetailId = x.FlightPassengerDetailId,
                        CreateAt = x.CreateAt,
                        UpdatedAt = x.UpdatedAt,
                        TicketId = x.TicketId,
                        PnrId = x.PnrId,
                        BookingId = x.BookingId,
                        CabinClass = x.CabinClass,
                        SeatNumber = x.SeatNumber,
                        CheckingStatus = x.CheckingStatus,
                        PaxType = x.PaxType,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        PassengerName = x.PassengerName,
                        Age = x.Age,
                        Title = x.Title,
                        Gender = x.Gender,
                        DateOfBirth = x.DateOfBirth,
                        ReservationStatus = x.ReservationStatus,
                        FfpNumber = x.FfpNumber,
                        Email = x.Email,
                        PhoneNumber = x.PhoneNumber,
                        PhoneNumberCountryCode = x.PhoneNumberCountryCode,
                        SegmentStatus = x.SegmentStatus,
                        InfantIndicator = x.InfantIndicator,
                        SsrCode = x.SsrCode,
                        FlightAt = x.FlightAt,
                        CheckinAt = x.CheckinAt,
                        TicketNumber = x.TicketNumber,
                        PnrNumber = x.PnrNumber,
                        PnrCreator = x.PnrCreator,
                        FlightNumber = x.FlightNumber,
                        FlightDate = x.FlightDate,
                    };
                    if (x.FlightScheduleId != null)
                        viewModels.FlightScheduleId = new LookupModels
                        {
                            LookupId = x.FlightScheduleId.LookupId,
                            LookupValue = x.FlightScheduleId.LookupValue
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

        public ApiResponse<string> InsertFlightPassengerDetail(List<FlightPassengerDetailRequestViewModels> data, ClientContext clientContext)
        {
            var apiResponse = new ApiResponse<string>();
            var arrMessage = new List<string>();

            try
            {
                var listFlightSchedule = FlightViewUtils.GetFlightSchedule(_clientContext);
                var res = new SPRespository(clientContext, Utils.BuildUrlList(clientContext, ListSPs.FlightPassengerDetail));
                foreach (var flightPassengerDetail in data)
                {
                    try
                    {
                        if (!flightPassengerDetail.FlightNumber.HasValue || !flightPassengerDetail.FlightDate.HasValue)
                        {
                            arrMessage.Add("Missing FlightNumber or FlightDate at " + flightPassengerDetail.FlightPassengerDetailId);
                            apiResponse.ErrorType = 400;
                            continue;
                        }
                        var flightSchedule = listFlightSchedule.FirstOrDefault(x =>
       flightPassengerDetail.FlightNumber != null && flightPassengerDetail.FlightDate != null &&int.Parse(x.FlightNumber) == flightPassengerDetail.FlightNumber.Value && x.FlightDate.HasValue && x.FlightDate.Value == flightPassengerDetail.FlightDate.Value);
                        if (flightSchedule == null)
                        {
                            arrMessage.Add(" FlightNumber or FlightDate not match at " + flightPassengerDetail.FlightPassengerDetailId);
                            apiResponse.ErrorType = 400;
                            continue;
                        }
                        var newItem = new FlightPassengerDetailSpModels(res, null)
                        {
                            FlightPassengerDetailId = flightPassengerDetail.FlightPassengerDetailId,
                            CreateAt = flightPassengerDetail.CreateAt,
                            UpdatedAt = flightPassengerDetail.UpdatedAt,
                            TicketId = flightPassengerDetail.TicketId,
                            PnrId = flightPassengerDetail.PnrId,
                            BookingId = flightPassengerDetail.BookingId,
                            FlightScheduleId = new FieldLookupValue { LookupId = flightSchedule.Id },
                            CabinClass = flightPassengerDetail.CabinClass,
                            SeatNumber = flightPassengerDetail.SeatNumber,
                            CheckingStatus = flightPassengerDetail.CheckingStatus,
                            PaxType = flightPassengerDetail.PaxType,
                            FirstName = flightPassengerDetail.FirstName,
                            LastName = flightPassengerDetail.LastName,
                            PassengerName = flightPassengerDetail.PassengerName,
                            Age = flightPassengerDetail.Age,
                            Title = flightPassengerDetail.Title,
                            Gender = flightPassengerDetail.Gender,
                            DateOfBirth = flightPassengerDetail.DateOfBirth,
                            ReservationStatus = flightPassengerDetail.ReservationStatus,
                            FfpNumber = flightPassengerDetail.FfpNumber,
                            Email = flightPassengerDetail.Email,
                            PhoneNumber = flightPassengerDetail.PhoneNumber,
                            PhoneNumberCountryCode = flightPassengerDetail.PhoneNumberCountryCode,
                            SegmentStatus = flightPassengerDetail.SegmentStatus,
                            InfantIndicator = flightPassengerDetail.InfantIndicator,
                            SsrCode = flightPassengerDetail.SsrCode,
                            FlightAt = flightPassengerDetail.FlightAt,
                            CheckinAt = flightPassengerDetail.CheckinAt,
                            TicketNumber = flightPassengerDetail.TicketNumber,
                            PnrNumber = flightPassengerDetail.PnrNumber,
                            PnrCreator = flightPassengerDetail.PnrCreator,
                            FlightNumber = flightPassengerDetail.FlightNumber,
                            FlightDate = flightPassengerDetail.FlightDate,
                        };
                        res.AddOrUpdate(newItem);
                        apiResponse.Content = new[] { Message.MessageApi.Success };
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
        #endregion
    }
}