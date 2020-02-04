using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Architecture.Generic.Infrastructure;
using Architecture.Generic.Models.ApiModel;
using Architecture.Data.Models.Entity;
using Architecture.Core.Infrastructure;
using Architecture.Core.Infrastructure.DataProvider;
using Architecture.Core.Infrastructure.IDataProvider;

namespace Architecture.Core.Infrastructure.Attributes
{
    public class ApiAuthorizationFilter : ActionFilterAttribute
    {
        public string Permissions { get; set; }
        public string[] PermissionList { get { return string.IsNullOrEmpty(Permissions) ? null : Permissions.Split(','); } set { Permissions = (value != null) ? string.Join(",", value) : ""; } }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            long userId = 0;
            #region LogApiRequest
            //Only For Testing Log Each Request in DB

            string filePath = HttpContext.Current.Request.FilePath;
            if (ConfigSettings.IsLoggedAPIRequest)
            {
                if (filePath.Length > 1)
                {
                    //if (!CheckAllowedActions())
                    //    userId = CacheApiHelper.UserId;

                    var strrequest = string.Empty;
                    var strheaders = string.Empty;
                    if (HttpContext.Current.Request.ContentLength > 0)
                    {
                        HttpContext.Current.Request.InputStream.Position = 0;
                        var inputStream = new StreamReader(HttpContext.Current.Request.InputStream);
                        strrequest = inputStream.ReadToEnd();//actionContext.ActionArguments.Count == 0 ? "NODATA" : Common.SerializeObject(actionContext.ActionArguments[Constants.RequestModelName]);
                    }
                    if (HttpContext.Current.Request.Headers.Count > 0)
                    {
                        strheaders = HttpContext.Current.Request.Headers.ToString();

                    }

                    var requestResponseLog = new RequestResponseLog
                    {
                        Type = "Request",
                        Data = strrequest,
                        Headers = strheaders,
                        Url = filePath,
                        UserId = userId
                    };

                    ITokenDataProvider _tokenDataProvider = new TokenDataProvider();
                    _tokenDataProvider.SaveRequestResponselog(requestResponseLog, userId);
                    HttpContext.Current.Request.ServerVariables["RequestResponseLogID"] = requestResponseLog.RequestResponseLogID.ToString();
                }
            }
            #endregion

            if (CacheApiHelper.IsValidKey())
            {
                if (CheckAllowedActions())
                {
                    base.OnActionExecuting(actionContext);
                    return;
                }

                if (!CacheApiHelper.IsAuthorizedUser())
                {
                    Common.SendApiResponse(actionContext,
                        new ServiceResponse
                        {
                            IsSuccess = false,
                            Message = string.Format("'{0}' Header is not passed or invalid.", Constants.KeyHeaderName)
                        }, HttpStatusCode.Unauthorized);
                }
                else
                {
                    base.OnActionExecuting(actionContext);
                    return;
                }
                //}
                //else
                //{
                //    Common.BadRequest(Common.ApiBadResponse(new ApiResponse()), actionContext);
                //}
            }
            else
            {
                Common.SendApiResponse(actionContext,
                        new ServiceResponse
                        {
                            IsSuccess = false,
                            Message = string.Format("'{0}' Header is not passed or invalid.", Constants.KeyHeaderName)
                        }, HttpStatusCode.NotAcceptable);
                return;
            }

        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            long userId = 0;
            //if (!CheckAllowedActions())
            //    userId = CacheApiHelper.UserId;

            #region LogApiResponse

            //Only For Testing Log Each Request in DB
            if (ConfigSettings.IsLoggedAPIRequest)
            {
                if (actionExecutedContext.Exception != null)
                {
                    RequestResponseLog requestResponseLog = new RequestResponseLog
                    {
                        Type = "Response",
                        Data = "ERRORRESPONSE:" + Common.SerializeObject(actionExecutedContext.Exception),
                        Url = actionExecutedContext.Request.RequestUri.AbsolutePath,
                        RefRequestResponseLogID = Convert.ToInt64(HttpContext.Current.Request.ServerVariables["RequestResponseLogID"]),
                        UserId = userId
                    };
                    ITokenDataProvider _tokenDataProvider = new TokenDataProvider();
                    _tokenDataProvider.SaveRequestResponselog(requestResponseLog, userId);

                }
                else
                {
                    var objectContent = actionExecutedContext.Response.Content as ObjectContent;
                    if (objectContent != null)
                    {

                        //var type = objectContent.ObjectType; //type of the returned object
                        var value = objectContent.Value; //holding the returned value
                        var str = Common.SerializeObject(value);
                        RequestResponseLog requestResponseLog = new RequestResponseLog
                        {
                            Type = "Response",
                            Data = str,
                            Headers = actionExecutedContext.Response.Headers.ToString(),
                            Url = actionExecutedContext.Request.RequestUri.AbsolutePath,
                            RefRequestResponseLogID = Convert.ToInt64(HttpContext.Current.Request.ServerVariables["RequestResponseLogID"]),
                            UserId = userId
                        };
                        ITokenDataProvider _tokenDataProvider = new TokenDataProvider();
                        _tokenDataProvider.SaveRequestResponselog(requestResponseLog, userId);
                    }

                }
            }

            #endregion LogApiResponse
        }



        private bool CheckAllowedActions()
        {
            string[] strPermissions = string.IsNullOrEmpty(Permissions) ? new string[] { } : Permissions.Split(',');

            if (strPermissions.Contains(Constants.AnonymousPermission))
                return true;

            if (!strPermissions.Any())
                return true;

            return false;
        }
    }
}
