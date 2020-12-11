using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BambooAirewayBE.API.Job;
using BambooAirewayBE.API.Models.ViewModels;
using BambooAirewayBE.API.Models.ViewRequests;
using BambooAirwayBE.API.Job;

namespace BambooAirewayBE.API.Controllers
{
    public class WorkingTimeController : ApiController
    {
        #region WorkingTime
        [HttpGet]
        [Route("api/WorkingTime/GetAllWorkingTime")]
        public HttpResponseMessage GetAllWorkingTime()
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var departmentJob = new WorkingTimeJob(clientContext);
                var allTimeKeepings = departmentJob.GetAllWorkingTime();
                if (allTimeKeepings.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allTimeKeepings);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allTimeKeepings);
            }
        }

        [HttpPost]
        [Route("api/WorkingTime/InsertWorkingTime")]
        public HttpResponseMessage InsertWorkingTime(List<WorkingTimeRequestModels> data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var departmentJob = new WorkingTimeJob(clientContext);
                var allTimeKeepings = departmentJob.InsertWorkingTime(data, clientContext);
                if (allTimeKeepings.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allTimeKeepings);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allTimeKeepings);
            }
        }
        #endregion

        #region Hr
        [HttpGet]
        [Route("api/WorkingTime/GetAllHr")]
        public HttpResponseMessage GetAllHr()
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var itemJob = new HrJob(clientContext);
                var allHr = itemJob.GetAllHr();
                if (allHr.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allHr);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allHr);
            }
        }

        [HttpPost]
        [Route("api/WorkingTime/InsertHr")]
        public HttpResponseMessage InsertHr(List<HrInsertModels> data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new HrJob(clientContext);
                var allTimeKeepings = job.InsertHr(data, clientContext);
                if (allTimeKeepings.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allTimeKeepings);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allTimeKeepings);
            }
        }

        [HttpPut]
        [Route("api/WorkingTime/UpdateHrByEmail")]
        public HttpResponseMessage UpdateHrByEmail(HrUpdateRequestModels data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new HrJob(clientContext);
                var allTimeKeepings = job.UpdateHrByEmail(data, clientContext);
                if (allTimeKeepings.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allTimeKeepings);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allTimeKeepings);
            }
        }

        [HttpGet]
        [Route("api/WorkingTime/GetByEmail")]
        public HttpResponseMessage GetByEmail([FromUri] string email)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                //var request = HttpContext.Current.Request;
                //var email = request.Params["email"];
                var itemJob = new HrJob(clientContext);
                var allHr = itemJob.GetByEmail(email, clientContext);
                if (allHr.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allHr);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allHr);
            }
        }


        #endregion

        #region TimeKeeping
        [HttpGet]
        [Route("api/TimeKeeping/GetAllTimeKeeping")]
        public HttpResponseMessage GetAllTimeKeeping()
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new TimeKeepingJob(clientContext);
                var allApi = job.GetAllTimeKeeping();
                if (allApi.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allApi);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allApi);
            }
        }

        [HttpPost]
        [Route("api/TimeKeeping/InsertTimeKeeping")]
        public HttpResponseMessage InsertTimeKeeping(List<TimeKeepingInsertModels> data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new TimeKeepingJob(clientContext);
                var allTimeKeepings = job.InsertTimeKeeping(data, clientContext);
                if (allTimeKeepings.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allTimeKeepings);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allTimeKeepings);
            }
        }


        #endregion

        #region Department
        [HttpGet]
        [Route("api/Department/GetAllDepartment")]
        public HttpResponseMessage GetAllDepartment()
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var departmentJob = new DepartmentJob(clientContext);
                var allTimeKeepings = departmentJob.GetAllDepartment();
                if (allTimeKeepings.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allTimeKeepings);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allTimeKeepings);
            }
        }

        [HttpPost]
        [Route("api/Department/InsertDepartment")]
        public HttpResponseMessage InsertDepartment(List<DepartmentRequestModels> data)
        {
            using (var clientContext = BambooAirwayBE.API.Utilities.Utils.Utils.InitializeClientContext())
            {
                var job = new DepartmentJob(clientContext);
                var allDepartment = job.InsertDepartment(data, clientContext);
                if (allDepartment.ErrorType != 400)
                    return Request.CreateResponse(HttpStatusCode.OK, allDepartment);
                return Request.CreateResponse(HttpStatusCode.BadRequest, allDepartment);
            }
        }


        #endregion
    }
}
