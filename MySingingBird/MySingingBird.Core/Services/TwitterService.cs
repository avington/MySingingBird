using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using MySingingBird.Core.Entities;
using MySingingBird.Core.Http;
using MySingingBird.Core.Map;
using MySingingBird.Entities;

namespace MySingingBird.Core.Services
{
    public class TwitterService : ITwitterService
    {
        private readonly IHttpRequestResponse _httpRequestResponse;
        private readonly IOAuthCreationService _oAuthCreationService;
        private readonly IMapUser _mapUser;

        public TwitterService(IHttpRequestResponse httpRequestResponse, IOAuthCreationService oAuthCreationService, IMapUser mapUser)
        {
            _httpRequestResponse = httpRequestResponse;
            _oAuthCreationService = oAuthCreationService;
            _mapUser = mapUser;
        }

        public string RequestToken()
        {
            throw new NotImplementedException();
        }

        public TwitterUser GetUser(string screenName)
        {
            if (string.IsNullOrEmpty(screenName)) return new TwitterUser();

            string url = "https://api.twitter.com/1/users/lookup.json";
            string fullUrl = string.Format("{0}?screen_name={1}&include_entities=true", url, screenName);

            string signatureString = _oAuthCreationService.CreateSignature(url);
            string authorizationHeaderParams = _oAuthCreationService.CreateAuthorizationHeaderParameter(
                signatureString, _oAuthCreationService.OAuthTimeStamp);

            string method = "POST";
            HttpWebRequest request = _httpRequestResponse.GetRequest(fullUrl, authorizationHeaderParams, method);
            var responseText = _httpRequestResponse.GetResponse(request);
            TwitterUser user = _mapUser.MapProfileInfo(responseText);
            return user;
        }

        public TwitterFollowers GetFollowers(string screenName)
        {
            if (string.IsNullOrEmpty(screenName)) return null;// new TwitterUser();

            string url = "https://api.twitter.com/1/followers/ids.json";
            string fullUrl = url + "?cursor=-1&screen_name=" + screenName;

            string signatureString = _oAuthCreationService.CreateSignature(url);
            string authorizationHeaderParams = _oAuthCreationService.CreateAuthorizationHeaderParameter(
                signatureString, _oAuthCreationService.OAuthTimeStamp);

            string method = "GET";
            HttpWebRequest request = _httpRequestResponse.GetRequest(fullUrl, authorizationHeaderParams, method);
            var responseText = _httpRequestResponse.GetResponse(request);
            TwitterFollowers followers = _mapUser.MapFollowers(responseText);
            return followers;

        }

        public TwitterFriends GetFriends(string screenName)
        {
            if (string.IsNullOrEmpty(screenName)) return null;// new TwitterUser();
            string url = "https://api.twitter.com/1/friends/ids.json";

            string fullUrl = url + "?cursor=-1&screen_name=" + screenName;

            string signatureString = _oAuthCreationService.CreateSignature(url);
            string authorizationHeaderParams = _oAuthCreationService.CreateAuthorizationHeaderParameter(
                signatureString, _oAuthCreationService.OAuthTimeStamp);

            string method = "GET";
            HttpWebRequest request = _httpRequestResponse.GetRequest(fullUrl, authorizationHeaderParams, method);
            var responseText = _httpRequestResponse.GetResponse(request);
            var friends = _mapUser.MapFriends(responseText);
            return friends; ;
        }
    }
}