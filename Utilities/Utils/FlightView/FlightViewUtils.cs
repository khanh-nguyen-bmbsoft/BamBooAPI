using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirewayBE.API.Models.SPModels;
using BambooAirewayBE.API.Models.SPModels.FlightView;
using BambooAirwayBE.API.Data;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Utilities.Utils.FlightView
{
    public static class FlightViewUtils
    {
        public static FlightScheduleSpModels[] GetFlightSchedule(ClientContext clientContext)
        {
            var res = new SPRespository(clientContext, BambooAirwayBE.API.Utilities.Utils.Utils.BuildUrlList(clientContext, Constants.Constants.ListSPJob.FlightSchedulesUrl));
            return res.GetAll((item) => new FlightScheduleSpModels(res, item)).ToArray();
        }
        public static FlightMemberSpModels[] GetFlightMembers(ClientContext clientContext)
        {
            var res = new SPRespository(clientContext, BambooAirwayBE.API.Utilities.Utils.Utils.BuildUrlList(clientContext, ListConstant.ListSPs.ListFlightMembers));
            return res.GetAll((item) => new FlightMemberSpModels(res, item)).ToArray();
        }
        public static FlightPassengerSpModels[] GetFlightPassengers(ClientContext clientContext)
        {
            var res = new SPRespository(clientContext, BambooAirwayBE.API.Utilities.Utils.Utils.BuildUrlList(clientContext, ListConstant.ListSPs.ListFlightPassengers));
            return res.GetAll((item) => new FlightPassengerSpModels(res, item)).ToArray();
        }
        public static FlightCrewSpModels[] GetFlightCrews(ClientContext clientContext)
        {
            var res = new SPRespository(clientContext, BambooAirwayBE.API.Utilities.Utils.Utils.BuildUrlList(clientContext, ListConstant.ListSPs.ListFlightCrews));
            return res.GetAll((item) => new FlightCrewSpModels(res, item)).ToArray();
        }

        public static FlightPassengerDetailSpModels[] GetFlightPassengerDetail(ClientContext clientContext)
        {
            var res = new SPRespository(clientContext, BambooAirwayBE.API.Utilities.Utils.Utils.BuildUrlList(clientContext, ListConstant.ListSPs.FlightPassengerDetail));
            return res.GetAll((item) => new FlightPassengerDetailSpModels(res, item)).ToArray();
        }
    }
}