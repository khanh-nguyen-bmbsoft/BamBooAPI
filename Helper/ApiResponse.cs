using System.Collections.Generic;
using System.Linq;
using System.Web.Http.ModelBinding;

namespace BambooAirewayBE.API.Helper
{
    public class ApiResponse<T>
    {
        public IEnumerable<T> Content { get; set; } 
        public int ErrorType { get; set; } 
        public IEnumerable<string> ErrorMessage { get; set; }

        public ApiResponse()
        {
            Content = new List<T>();
            ErrorType = 200;
            ErrorMessage = new List<string>();
        }
        //public ApiResponse(ModelStateDictionary modelState)
        //{
        //    Content=new List<T>();
        //    ErrorType = 400;
        //    ErrorMessage = modelState.SelectMany(x => x.Value.Errors).Select(x => x.ErrorMessage).ToArray();
        //}
    }
}