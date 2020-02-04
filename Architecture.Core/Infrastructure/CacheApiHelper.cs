using System;
using System.Net;
using System.Runtime.Caching;
using System.Web;
using Architecture.Generic.Infrastructure;
using Architecture.Generic.Models.ApiModel;
using Architecture.Generic.Models.ViewModel;
using Architecture.Core.Infrastructure.DataProvider;
using Architecture.Core.Infrastructure.IDataProvider;

namespace Architecture.Core.Infrastructure
{
    public static class CacheApiHelper
    {
        public static string Key
        {
            get
            {
                var a = HttpContext.Current.Request.Headers[Constants.KeyHeaderName];
                if (!string.IsNullOrEmpty(a))
                {
                    return a;
                }

                return null;
            }
        }

        public static string Token
        {
            get
            {
                var a = HttpContext.Current.Request.Headers[Constants.TokenHeaderName];
                if (!string.IsNullOrEmpty(a))
                {
                    return a.Replace("Token ", "");
                }

                return null;
            }
        }

        //public static long UserId
        //{
        //    get
        //    {
        //        var cacheModel = AuthenticateToken();
        //        if (cacheModel != null)
        //            return cacheModel.UserId;

        //        return 0;
        //    }
        //}

        public static LoginTokenModel AuthenticateToken()
        {
            ObjectCache cache = MemoryCache.Default;
            if (!string.IsNullOrEmpty(Token))
            {
                if (cache.Contains(Token))
                {
                    LoginTokenModel tokenvalue = (LoginTokenModel)cache.Get(Token);

                    //Code For Making Cache Extended.
                    CacheItem item = cache.GetCacheItem(Token);
                    CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                    cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddMinutes(ConfigSettings.CacheExpiryPeriod);
                    cache.Set(item, cacheItemPolicy);
                    return tokenvalue;
                }
                else
                {
                    ITokenDataProvider _securityDataProvider = new TokenDataProvider();
                    ServiceResponse response = _securityDataProvider.AuthenticateToken(Token);
                    if (response.IsSuccess)
                    {
                        LoginTokenModel tokenvalue = (LoginTokenModel)response.Data;
                        CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                        cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddMinutes(ConfigSettings.CacheExpiryPeriod);
                        cache.Add(Token, tokenvalue, cacheItemPolicy);
                        return tokenvalue;
                    }

                }
            }

            Common.ThrowErrorMessage("Invalid token or token expired.", HttpStatusCode.Unauthorized);
            return null;
        }

        public static bool IsAuthorizedUser()
        {
            return AuthenticateToken() != null;
        }

        public static bool IsValidKey()
        {
            return !string.IsNullOrEmpty(Key) && Key == ConfigSettings.ApiAccessKey;
        }

        public static ServiceResponse RemoveToken()
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Remove(Token);
            ITokenDataProvider _securityDataProvider = new TokenDataProvider();
            return _securityDataProvider.RemoveToken(Token);
        }
    }
}
