using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySingingBird.Core.Http;

namespace MySingingBird.Core.Application
{
    public class AppSettings : IAppSettings
    {

        private readonly IHttpServer _httpServer;

        public AppSettings(IHttpServer httpServer)
        {
            _httpServer = httpServer;
        }

        /*
         * 
         * Consumer key13Cc5m8F54hjR4o5jypuw
         * Consumer secret  r1JGeMdiN2zGZsuljhWnpQB04T6ePAldrkLPUhxsqE
         * Request token URL    https://api.twitter.com/oauth/request_token
         * Authorize URL https://api.twitter.com/oauth/authorize
         * Access token URL https://api.twitter.com/oauth/access_token
         * */

        public string ConsumerKey
        {
            get { return "key13Cc5m8F54hjR4o5jypuw"; }
        }

        public string ConsumerSecret
        {
            get { return "r1JGeMdiN2zGZsuljhWnpQB04T6ePAldrkLPUhxsqE"; }
        }

        public string RequestTokenUrl
        {
            get { return "https://api.twitter.com/oauth/request_token"; }
        }

        public string AthorizeUrl
        {
            get { return "https://api.twitter.com/oauth/authorize"; }
        }

        public string AccessTokenUrl
        {
            get { return "https://api.twitter.com/oauth/access_token"; }
        }

        public string TwitterBaseUrl
        {
            get { return "http://api.twitter.com/1/"; }
        }

        public string OathNonce
        {
            get { return Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString())); }
        }

        public string OathSignatureMethod
        {
            get { return "HMAC-SHA1"; }
        }


        public string OathTimeStamp
        {
            get
            {
                var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return Convert.ToInt64(ts.TotalSeconds).ToString();
            }
        }

        public string CallbackUrl
        {
            get { return _httpServer.UrlEncode( "http://localhost:9355/Manage/Index"); }
        }

        public string OathVersion
        {
            get { return "1.0"; }
        }
    }
}
