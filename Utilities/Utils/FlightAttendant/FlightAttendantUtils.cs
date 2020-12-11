using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BambooAirewayBE.API.Models.SPModels.FlightAttendant;
using BambooAirewayBE.API.Models.SPModels.FlightView;
using BambooAirewayBE.API.Models.ViewModels.FlightAttendant;
using BambooAirwayBE.API.Data;
using Microsoft.SharePoint.Client;

namespace BambooAirewayBE.API.Utilities.Utils.FlightAttendant
{
    public class FlightAttendantUtils
    {
        public static FlightAttendantProfileSpModels[] GetFlightAttendantProfile(ClientContext clientContext)
        {
            var res = new SPRespository(clientContext, BambooAirwayBE.API.Utilities.Utils.Utils.BuildUrlList(clientContext, ListConstant.ListSPs.ListFlightAttendantProfile));
            return res.GetAll((item) => new FlightAttendantProfileSpModels(res, item)).ToArray();
        }

        public static FlightAttendantTitleSpModels[] GetFlightAttendantTitle(ClientContext clientContext)
        {
            var res = new SPRespository(clientContext, BambooAirwayBE.API.Utilities.Utils.Utils.BuildUrlList(clientContext, ListConstant.ListSPs.ListFlightAttendantTitle));
            return res.GetAll((item) => new FlightAttendantTitleSpModels(res, item)).ToArray();
        }

        public static ReviewCategorySpModels[] GetReviewCategory(ClientContext clientContext)
        {
            var res = new SPRespository(clientContext, BambooAirwayBE.API.Utilities.Utils.Utils.BuildUrlList(clientContext, ListConstant.ListSPs.ListReviewCategory));
            return res.GetAll((item) => new ReviewCategorySpModels(res, item)).ToArray();
        }

        public static TitleTemplateSpModels[] GetTitleTemplate(ClientContext clientContext)
        {
            var res = new SPRespository(clientContext, BambooAirwayBE.API.Utilities.Utils.Utils.BuildUrlList(clientContext, ListConstant.ListSPs.ListTitleTemplate));
            return res.GetAll((item) => new TitleTemplateSpModels(res, item)).ToArray();
        }

        public static ResultDetailFlightAttendantSpModels[] GetResultDetailFlightAttendant(ClientContext clientContext)
        {
            var res = new SPRespository(clientContext, BambooAirwayBE.API.Utilities.Utils.Utils.BuildUrlList(clientContext, ListConstant.ListSPs.ListResultDetailFlightAttendant));
            return res.GetAll((item) => new ResultDetailFlightAttendantSpModels(res, item)).ToArray();
        }

        public static ResultFlightSpModels[] GetResultFlight(ClientContext clientContext)
        {
            var res = new SPRespository(clientContext, BambooAirwayBE.API.Utilities.Utils.Utils.BuildUrlList(clientContext, ListConstant.ListSPs.ListResultFlight));
            return res.GetAll((item) => new ResultFlightSpModels(res, item)).ToArray();
        }
    }
}