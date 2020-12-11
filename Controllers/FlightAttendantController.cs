using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BambooAirewayBE.API.Job;
using BambooAirewayBE.API.Models.ViewModels.FlightAttendant;
using BambooAirewayBE.API.Models.ViewModels.FlightViewModels;

namespace BambooAirewayBE.API.Controllers
{
    [RoutePrefix("api/FlightAttendant")]
    public class FlightAttendantController : ApiController
    {
        [HttpGet]
        [Route("FlightAttendantProfile/GetAllProfile")]
        public HttpResponseMessage GetAllProfile()
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightAttendantJob(clientContext);
                var allTimeKeepings = job.GetAllProfile();
                if (allTimeKeepings.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allTimeKeepings);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allTimeKeepings);
            }
        }

        [HttpPost]
        [Route("FlightAttendantProfile/InsertProfile")]
        public HttpResponseMessage InsertProfile(List<FlightAttendantProfileRequestViewModels> data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightAttendantJob(clientContext);
                var allItem = job.InsertProfile(data, clientContext);
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }

        [HttpGet]
        [Route("FlightAttendantTitle/GetAllFlightAttendantTitle")]
        public HttpResponseMessage GetAllFlightAttendantTitle()
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightAttendantJob(clientContext);
                var allTimeKeepings = job.GetAllFlightAttendantTitle();
                if (allTimeKeepings.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allTimeKeepings);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allTimeKeepings);
            }
        }

        [HttpPost]
        [Route("FlightAttendantTitle/InsertFlightAttendantTitle")]
        public HttpResponseMessage InsertFlightAttendantTitle(List<FlightAttendantTitleRequestViewModels> data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightAttendantJob(clientContext);
                var allItem = job.InsertFlightAttendantTitle(data, clientContext);
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }

        [HttpGet]
        [Route("ReviewCategory/GetAllReviewCategory")]
        public HttpResponseMessage GetAllReviewCategory()
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightAttendantJob(clientContext);
                var allTimeKeepings = job.GetAllReviewCategory();
                if (allTimeKeepings.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allTimeKeepings);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allTimeKeepings);
            }
        }

        [HttpPost]
        [Route("ReviewCategory/InsertReviewCategory")]
        public HttpResponseMessage InsertReviewCategory(List<ReviewCategoryRequestViewModels> data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightAttendantJob(clientContext);
                var allItem = job.InsertReviewCategory(data, clientContext);
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }

        [HttpGet]
        [Route("TitleTemplate/GetAllTitleTemplate")]
        public HttpResponseMessage GetAllTitleTemplate()
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightAttendantJob(clientContext);
                var allTimeKeepings = job.GetAllTitleTemplate();
                if (allTimeKeepings.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allTimeKeepings);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allTimeKeepings);
            }
        }

        [HttpPost]
        [Route("TitleTemplate/InsertTitleTemplate")]
        public HttpResponseMessage InsertTitleTemplate(List<TitleTemplateRequestViewModels> data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightAttendantJob(clientContext);
                var allItem = job.InsertTitleTemplate(data, clientContext);
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }

        [HttpGet]
        [Route("ResultDetailFlightAttendant/GetAllResultDetailFlightAttendant")]
        public HttpResponseMessage GetAllResultDetailFlightAttendant()
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightAttendantJob(clientContext);
                var allTimeKeepings = job.GetAllResultDetailFlightAttendant();
                if (allTimeKeepings.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allTimeKeepings);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allTimeKeepings);
            }
        }

        [HttpPost]
        [Route("ResultDetailFlightAttendant/InsertResultDetailFlightAttendant")]
        public HttpResponseMessage InsertResultDetailFlightAttendant(List<ResultDetailFlightAttendantRequestViewModels> data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightAttendantJob(clientContext);
                var allItem = job.InsertResultDetailFlightAttendant(data, clientContext);
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }

        [HttpGet]
        [Route("ResultFlight/GetAllResultFlight")]
        public HttpResponseMessage GetAllResultFlight()
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightAttendantJob(clientContext);
                var allTimeKeepings = job.GetAllResultFlight();
                if (allTimeKeepings.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allTimeKeepings);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allTimeKeepings);
            }
        }

        [HttpPost]
        [Route("ResultFlight/InsertResultFlight")]
        public HttpResponseMessage InsertResultFlight(List<ResultFlightRequestViewModels> data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightAttendantJob(clientContext);
                var allItem = job.InsertResultFlight(data, clientContext);
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }

    }
}
