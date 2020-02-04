
namespace Architecture.Generic.Infrastructure
{
    public class StatusCode
    {
        #region StoredProcedure StatusCode

        /// <summary>
        /// Shown validation error msg
        /// </summary>
        public const string StatusCode1001 = "1001";

        /// <summary>
        /// Duplicate
        /// </summary>
        public const string StatusCode1002 = "1002";

        /// <summary>
        /// Already in used.
        /// </summary>
        public const string StatusCode1003 = "1003";

        /// <summary>
        /// Blocked.
        /// </summary>
        public const string StatusCode1004 = "1004";
        
        /// <summary>
        /// Expired.
        /// </summary>
        public const string StatusCode1005 = "1005";

        /// <summary>
        /// Not founds, Not Matched
        /// </summary>
        public const string StatusCode1007 = "1007";

        /// <summary>
        /// Message with user affection
        /// </summary>
        public const string StatusCode1009 = "1009";

        /// <summary>
        /// Application manager Login Token expired or not found
        /// </summary>
        public static string StatusCode1010 = "1010";

        /// <summary>
        /// Sp transaction(insert, update, delete) successful.
        /// </summary>
        public const string StatusCode2002 = "2002";

        #endregion StoredProcedure StatusCode

        /// <summary>
        /// return OK.
        /// </summary>
        public static string StatusCode0 = "0";
        /// <summary>
        /// return false
        /// </summary>
        public static string StatusCode1 = "1";

        /// <summary>
        /// Bad Request. Problem with the request, such as a missing, invalid or type mismatched parameter
        /// </summary>
        public static string StatusCode400 = "400";

        /// <summary>
        /// Unauthorized. Invalid or missing api key.
        /// </summary>
        public static string StatusCode401 = "401";
        /// <summary>
        /// Forbidden. Disabled api key, or you do not have access to this resource
        /// </summary>
        public static string StatusCode403 = "403";

        /// <summary>
        /// Not Found. Requested resource doesn't exist. A request made over HTTP instead of HTTPS will also result in this error.
        /// </summary>
        public static string StatusCode404 = "404";

        /// <summary>
        /// Already Exists. Request could not be completed due to a conflict with the current state of the resource
        /// </summary>
        public static string StatusCode409 = "409";

        /// <summary>
        /// Token expired or not found
        /// </summary>
        public static string StatusCode410 = "410";

        /// <summary>
        /// Server Error. An uncaught exception has occurred on the server.
        /// </summary>
        public static string StatusCode500 = "500";
        
    }
}