using Newtonsoft.Json;
using Architecture.Generic.Models;
using System.Collections.Generic;
using System;
using System.IO;
using Architecture.Generic.Models.ApiModel;
using System.Net;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace Architecture.Generic.Infrastructure
{
    public class Common
    {
        #region Serialize/Deserialize Object

        public static string SerializeObject<T>(T objectData)
        {
            string defaultJson = JsonConvert.SerializeObject(objectData);
            return defaultJson;
        }

        public static T DeserializeObject<T>(string json)
        {
            T obj = default(T);
            obj = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return obj;
        }

        #endregion

        #region Generate Response

        public static ServiceResponse GenerateResponse(string message = "", bool isSuccess = false)
        {
            ServiceResponse response = new ServiceResponse();
            response.Message = message;
            response.IsSuccess = isSuccess;
            return response;
        }

        //Don't Use This function in DataProvider Only Use in Controller or Authentication
        public static void SendApiResponse(ServiceResponse response, int statusCode = (int)HttpStatusCode.BadRequest)
        {
            HttpContext.Current.Response.Clear();
            if (statusCode == (int)HttpStatusCode.Unauthorized)
            {
                HttpContext.Current.Response.Headers.Add("WWW-Authenticate", "Token");
            }

            HttpContext.Current.Response.StatusCode = statusCode;
            HttpContext.Current.Response.Write(SerializeObject(response));
            HttpContext.Current.Response.End();
        }

        //Don't Use This function in DataProvider Only Use in Controller or Authentication
        public static void SendApiResponse(HttpActionContext actionContext, ServiceResponse response, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            var resp = actionContext.Request.CreateResponse(
                statusCode,
                response,
                actionContext.ControllerContext.Configuration.Formatters.JsonFormatter
            );

            if (statusCode == HttpStatusCode.Unauthorized)
            {
                HttpContext.Current.Response.Headers.Add("WWW-Authenticate", "Token");
            }

            actionContext.Response = resp;
        }

        public static void BadRequest(ApiResponse response, HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(
                HttpStatusCode.NotAcceptable,
                response,
                actionContext.ControllerContext.Configuration.Formatters.JsonFormatter
                );
        }

        public static void ThrowErrorMessage(string Message, HttpStatusCode code = HttpStatusCode.NotFound)
        {
            var resp = new HttpResponseMessage(code)
            {
                Content = new StringContent(Message),
                ReasonPhrase = Message,
            };
            throw new HttpResponseException(resp);
        }

        #endregion

        public static List<SearchValueData> SetPagingParams(int pageIndex, int pageSize, string sortIndex = "", string sortDirection = "")
        {
            var searchData = new List<SearchValueData>();
            searchData.Add(new SearchValueData { Name = "FromIndex", Value = Convert.ToString(((pageIndex - 1) * pageSize) + 1) });
            searchData.Add(new SearchValueData { Name = "ToIndex", Value = Convert.ToString(pageIndex * pageSize) });
            if (!string.IsNullOrEmpty(sortIndex))
                searchData.Add(new SearchValueData { Name = "SortExpression", Value = sortIndex });//Field Name
            if (!string.IsNullOrEmpty(sortDirection))
                searchData.Add(new SearchValueData { Name = "SortType", Value = sortDirection });//ASC or DESC
            return searchData;
        }

        public static void CreateLogFile(string message, long userID, string logFileName = "", string logPath = "")
        {
            if (string.IsNullOrEmpty(logFileName))
                logFileName = "Exception";

            if (string.IsNullOrEmpty(logPath))
                logPath = System.Web.Hosting.HostingEnvironment.MapPath(ConfigSettings.LogPath);

            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            string fileName = logPath + logFileName + "_" + userID + "_" + DateTime.UtcNow.ToString("MMddyyyy") + ".txt";  //DateTime.Today.ToString("MMddyyyyhhmmss") + ".txt";
            //string fileName = logPath + DateTime.Today.ToString(Constants.DateFormatDashed) + ".txt";

            var sr = new StreamWriter(fileName, true);
            sr.WriteLine("Date:" + DateTime.Now.ToString(Constants.DateFormatSlash));
            sr.WriteLine(message);
            sr.WriteLine("=====================================================================================================================================================================");
            sr.Flush();
            sr.Close();
        }
    }
}
