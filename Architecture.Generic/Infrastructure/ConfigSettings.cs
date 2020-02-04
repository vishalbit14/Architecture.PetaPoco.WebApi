using System;
using System.Configuration;

namespace Architecture.Generic.Infrastructure
{
    public class ConfigSettings
    {
        public static readonly string ConnectionStringName = ConfigurationManager.AppSettings["ConnectionStringName"];
        public static readonly string SiteBaseUrl = ConfigurationManager.AppSettings["SiteBaseUrl"];

        public static readonly bool IsLoggedAPIRequest = Convert.ToBoolean(ConfigurationManager.AppSettings["IsLoggedAPIRequest"]);
        public static readonly string ApiAccessKey = ConfigurationManager.AppSettings["ApiAccessKey"];

        public static readonly long TokenExpiryPeriod = Convert.ToInt64(ConfigurationManager.AppSettings["TokenExpiryPeriod"]);
        public static readonly long CacheExpiryPeriod = Convert.ToInt64(ConfigurationManager.AppSettings["CacheExpiryPeriod"]);

        public static readonly bool IsLocal = Convert.ToBoolean(ConfigurationManager.AppSettings["IsLocal"]);

        public static readonly string UploadPath = Convert.ToString(ConfigurationManager.AppSettings["UploadPath"]);
        public static readonly string LogPath = Convert.ToString(ConfigurationManager.AppSettings["LogPath"]);
    }
}
