using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MySingingBird.Core.Application;
using MySingingBird.Core.Http;
using MySingingBird.Core.Services;

namespace MySingingBird.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppSettings _appSettings;
        private readonly ITwitterService _twitterService;
        private readonly IHttpRequestResponse _httpRequestResponse;

        public HomeController(ITwitterService twitterService, IAppSettings appSettings, IHttpRequestResponse httpRequestResponse)
        {
            _twitterService = twitterService;
            _appSettings = appSettings;
            _httpRequestResponse = httpRequestResponse;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to My Singing Bird!";

            return View();
        }

        

        public ActionResult Authorize()
        {
            string token = _twitterService.RequestToken();
            return Redirect(_appSettings.AthorizeUrl + token);
        }

        public ActionResult Test()
        {

            
            string oauth_consumer_key = "13Cc5m8F54hjR4o5jypuw";
            string oauth_nonce = Convert.ToBase64String(
                new ASCIIEncoding().GetBytes(
                    DateTime.Now.Ticks.ToString()));

            string oauth_signature_method = "HMAC-SHA1";
            string oauth_token =
                "22260330-LpsfgabOaTNXaySOSPLk9qGM8FqyhfRPKx6WJnSRd";

            TimeSpan ts = DateTime.UtcNow -
                new DateTime(1970, 1, 1, 0, 0, 0, 0);

            string oauth_timestamp =
                Convert.ToInt64(ts.TotalSeconds).ToString();

            string oauth_version = "1.0";

            //GS - When building the signature string the params
            //must be in alphabetical order. I can't be bothered
            //with that, get SortedDictionary to do it's thing
            SortedDictionary<string, string> sd =
                new SortedDictionary<string, string>();

            sd.Add("oauth_version", oauth_version);
            sd.Add("oauth_consumer_key", oauth_consumer_key);
            sd.Add("oauth_nonce", oauth_nonce);
            sd.Add("oauth_signature_method", oauth_signature_method);
            sd.Add("oauth_timestamp", oauth_timestamp);
            sd.Add("oauth_token", oauth_token);

            //GS - Build the signature string
            string baseString = String.Empty;
            baseString += "POST" + "&";
            baseString += Uri.EscapeDataString(
                "http://api.twitter.com/1/users/lookup.json")
                + "&";

            foreach (KeyValuePair<string, string> entry in sd)
            {
                baseString += Uri.EscapeDataString(entry.Key +
                    "=" + entry.Value + "&");
            }

            //GS - Remove the trailing ambersand char, remember
            //it's been urlEncoded so you have to remove the
            //last 3 chars - %26
            baseString =
                baseString.Substring(0, baseString.Length - 3);

            //GS - Build the signing key
            string consumerSecret =
                "YourSecret";

            string oauth_token_secret =
                "YOurToken";

            string signingKey =
                Uri.EscapeDataString(consumerSecret) + "&" +
                Uri.EscapeDataString(oauth_token_secret);

            //GS - Sign the request
            HMACSHA1 hasher = new HMACSHA1(
                new ASCIIEncoding().GetBytes(signingKey));

            string signatureString = Convert.ToBase64String(
                hasher.ComputeHash(
                new ASCIIEncoding().GetBytes(baseString)));

            //GS - Tell Twitter we don't do the 100 continue thing
            ServicePointManager.Expect100Continue = false;

            //GS - Instantiate a web request and populate the
            //authorization header
            HttpWebRequest hwr =
                (HttpWebRequest)WebRequest.Create(
                @"https://api.twitter.com/1/users/lookup.json?screen_name=siravington&include_entities=true");

            string authorizationHeaderParams = String.Empty;
            authorizationHeaderParams += "OAuth ";
            authorizationHeaderParams += "oauth_nonce=" + "\"" +
                Uri.EscapeDataString(oauth_nonce) + "\",";

            authorizationHeaderParams +=
                "oauth_signature_method=" + "\"" +
                Uri.EscapeDataString(oauth_signature_method) +
                "\",";

            authorizationHeaderParams += "oauth_timestamp=" + "\"" +
                Uri.EscapeDataString(oauth_timestamp) + "\",";

            authorizationHeaderParams += "oauth_consumer_key="
                + "\"" + Uri.EscapeDataString(
                oauth_consumer_key) + "\",";

            authorizationHeaderParams += "oauth_token=" + "\"" +
                Uri.EscapeDataString(oauth_token) + "\",";

            authorizationHeaderParams += "oauth_signature=" + "\""
                + Uri.EscapeDataString(signatureString) + "\",";

            authorizationHeaderParams += "oauth_version=" + "\"" +
                Uri.EscapeDataString(oauth_version) + "\"";

            hwr.Headers.Add(
                "Authorization", authorizationHeaderParams);

            //GS - POST off the request
            hwr.Method = "POST";
            //hwr.ContentType = "application/x-www-form-urlencoded";
            //Stream stream = hwr.GetRequestStream();
            //byte[] bodyBytes =
            //    new ASCIIEncoding().GetBytes(postBody);

            //stream.Write(bodyBytes, 0, bodyBytes.Length);
            //stream.Flush();
            //stream.Close();

            //GS - Allow us a reasonable timeout in case
            //Twitter's busy
            hwr.Timeout = 3 * 60 * 1000;

            try
            {
                using (var response = hwr.GetResponse() as HttpWebResponse)
                {
                    if (response != null && response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new ApplicationException(
                            string.Format("The request did not compplete successfully and returned status code:{0}",
                                          response.StatusCode));
                    }
                    if (response != null)
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            ViewData["response"] =reader.ReadToEnd();
                        }
                }
                //GS - Do something with the return here...
            }
            catch (WebException e)
            {
                //GS - Do some clever error handling here...
            }
            return View();
        }
    }
}
