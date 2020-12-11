using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace BambooAirewayBE.API.Helper
{
    public class ApiValidateModelAttribute : ActionFilterAttribute
    {
        //public override void OnActionExecuting(HttpActionContext actionContext)
        //{
        //    if (!actionContext.ModelState.IsValid)
        //    {
        //        //actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest,
        //        //    new ApiResponse<string>(actionContext.ModelState));
        //    }
        //}
    }
}