using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BambooAirewayBE.API.Job;
using BambooAirewayBE.API.Models.ViewModels.FlightViewModels;

namespace BambooAirewayBE.API.Controllers
{
    public class FlightViewController : ApiController
    {
        #region FlightSchedules
        [HttpGet]
        [Route("api/FlightSchedules/GetAllFlightSchedules")]
        public HttpResponseMessage GetAllFlightSchedules()
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightScheduleJob(clientContext);
                var allItem = job.GetAllFlightSchedules();
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }

        [HttpPost]
        [Route("api/FlightSchedules/InsertFlightSchedules")]
        public HttpResponseMessage InsertFlightSchedules(List<FlightScheduleRequestViewModels> data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightScheduleJob(clientContext);
                var allItem = job.InsertFlightSchedules(data, clientContext);
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }

        [HttpGet]
        [Route("api/FlightSchedules/GetByFlightDateFlightSchedules")]
        public HttpResponseMessage GetByFlightDate(GetByFlightDateRequest data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightScheduleJob(clientContext);
                var allItem = job.GetByFlightDate(data, clientContext);
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }

        [HttpGet]
        [Route("api/FlightSchedules/GetFlDateAndFlNumberFlightSchedules")]
        public HttpResponseMessage GetFlDateAndFlNumber(GetByFlightDateAndFlightNumberRequest data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightScheduleJob(clientContext);
                var allItem = job.GetFlDateAndFlNumber(data, clientContext);
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }
        #endregion

        #region FlightMembers
        [HttpGet]
        [Route("api/FlightMembers/GetAllFlightMembers")]
        public HttpResponseMessage GetAllFlightMembers()
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightScheduleJob(clientContext);
                var allItem = job.GetAllFlightMembers();
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }
     
        [HttpGet]
        [Route("api/FlightMembers/GetByFlightDateFlightMembers")]
        public HttpResponseMessage GetByFlightDateFlightMembers(GetFlDateAndFlNumberMemberModels data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightScheduleJob(clientContext);
                var allItem = job.GetByFlightDateFlightMembers(data, clientContext);
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }

        [HttpPost]
        [Route("api/FlightMembers/InsertFlightMembers")]
        public HttpResponseMessage InsertFlightMembers(List<FlightMemberRequestViewModels> data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightScheduleJob(clientContext);
                var allItem = job.InsertFlightMembers(data, clientContext);
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }
        #endregion

        #region FlightPassengers
        [HttpGet]
        [Route("api/FlightPassengers/GetAllFlightPassengers")]
        public HttpResponseMessage GetAllFlightPassengers()
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightScheduleJob(clientContext);
                var allItem = job.GetAllFlightPassengers();
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }

        [HttpGet]
        [Route("api/FlightPassengers/GetByFlDateAndFlNumberPassenger")]
        public HttpResponseMessage GetByFlDateAndFlNumberPassenger(FlightPassengerGetflDateAndflNumber data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightScheduleJob(clientContext);
                var allItem = job.GetByFlDateAndFlNumberPassenger(data, clientContext);
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }

        [HttpPost]
        [Route("api/FlightPassengers/InsertFlightPassengers")]
        public HttpResponseMessage InsertFlightPassengers(List<FlightPassengerRequestViewModels> data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightScheduleJob(clientContext);
                var allItem = job.InsertFlightPassengers(data, clientContext);
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }
        #endregion

        #region FlightCrews
        [HttpGet]
        [Route("api/FlightCrews/GetAllFlightCrews")]
        public HttpResponseMessage GetAllFlightCrews()
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightScheduleJob(clientContext);
                var allItem = job.GetAllFlightCrews();
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }

        [HttpGet]
        [Route("api/FlightCrews/GetByFlightDateFlightCrew")]
        public HttpResponseMessage GetCrewflDateAndflNumber(GetFlDateAndFlNumberMemberModels data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightScheduleJob(clientContext);
                var allItem = job.GetCrewflDateAndflNumber(data, clientContext);
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }

        [HttpPost]
        [Route("api/FlightCrews/InsertFlightCrews")]
        public HttpResponseMessage InsertFlightCrews(List<FlightCrewRequestViewModels> data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightScheduleJob(clientContext);
                var allItem = job.InsertFlightCrews(data, clientContext);
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }
        #endregion

        #region FlightPassengerDetail
        [HttpGet]
        [Route("api/FlightPassengerDetail/GetAllFlightPassengerDetail")]
        public HttpResponseMessage GetAllFlightPassengerDetail()
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightScheduleJob(clientContext);
                var allItem = job.GetAllFlightPassengerDetail();
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }

        [HttpPost]
        [Route("api/FlightPassengerDetail/InsertFlightPassengerDetail")]
        public HttpResponseMessage InsertFlightPassengerDetail(List<FlightPassengerDetailRequestViewModels> data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new FlightScheduleJob(clientContext);
                var allItem = job.InsertFlightPassengerDetail(data, clientContext);
                if (allItem.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allItem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allItem);
            }
        }
        #endregion

    }
}
