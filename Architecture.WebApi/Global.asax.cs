using System.Linq;
using System.Web;
using System.Web.Http;

namespace Architecture.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest()
        {
            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {
                if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
                {
                    //These headers are handling the "pre-flight" OPTIONS call sent by the browser

                    // HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://caseratiotest.3c5oylwvcnloivml.maxcdn-edge.com,https://caseratiotest-3c5oylwvcnloivml.netdna-ssl.com");
                    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
                    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "*");
                    HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "60");
                    HttpContext.Current.Response.End();
                }
            }
            else
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
            }
        }
    }
}
