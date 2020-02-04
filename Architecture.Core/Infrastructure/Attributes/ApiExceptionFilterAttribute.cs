using System.Web.Http;
using Elmah;
using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using Architecture.Generic.Models.ApiModel;
using Architecture.Generic.Infrastructure;

namespace Architecture.Data.Infrastructure.Attributes
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        ///  This method called when any exception occure in web api call. 
        ///  also this method used for log error in elmah.
        /// </summary>
        public override void OnException(HttpActionExecutedContext context)
        {
            if ((context.Exception is HttpResponseException))
            {
                Common.SendApiResponse(context.ActionContext,
                    new ServiceResponse
                    {
                        Message = ((HttpResponseException)context.Exception).Response.ReasonPhrase,
                        IsSuccess = false
                    });
                return;
            }

            var response = new ServiceResponse
            {
                Message = "Server Error",
                Data = Common.SerializeObject(context.Exception),
                IsSuccess = false
            };
            Common.SendApiResponse(context.ActionContext, response);

            // Handle elmah error
            var e = context.Exception;
            RaiseErrorSignal(e);
            context.Response = context.ActionContext.Request.CreateResponse(HttpStatusCode.BadRequest, response);
            ErrorLog.GetDefault(HttpContext.Current).Log(new Error(context.Exception));
        }

        private static void RaiseErrorSignal(Exception e)
        {
            var context = HttpContext.Current;
            if (context == null)
                return;
            var signal = ErrorSignal.FromContext(context);
            if (signal == null)
                return;
            signal.Raise(e, context);
        }
    }
}