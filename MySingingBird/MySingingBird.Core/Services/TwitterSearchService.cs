using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using MySingingBird.Core.Entities;
using MySingingBird.Core.Http;
using MySingingBird.Core.Map;
using MySingingBird.Core.ViewModel;
using MySingingBird.Entities;

namespace MySingingBird.Core.Services
{
    public class TwitterSearchService : ITwitterSearchService
    {
        private readonly IHttpRequestResponse _httpRequestResponse;
        private readonly IOAuthCreationService _oAuthCreationService;
        private readonly IHttpServer _httpServer;
        private readonly IMapSearch _mapSearch;
        

        public TwitterSearchService(IHttpRequestResponse httpRequestResponse, IOAuthCreationService oAuthCreationService, IMapUser mapUser, IHttpServer httpServer, IMapSearch mapSearch)
        {
            _httpRequestResponse = httpRequestResponse;
            _oAuthCreationService = oAuthCreationService;
            _httpServer = httpServer;
            _mapSearch = mapSearch;
        }



        public IList<SearchResponse> Search(SearchRequest search)
        {
            if (search == null || string.IsNullOrEmpty(search.Q)) return new List<SearchResponse>();
            /*
             * http://search.twitter.com/search.json?q=blue%20angels&rpp=5&include_entities=true&result_type=mixed
             * */
            string query = _httpServer.UrlEncode(search.Q);
            
            string url = "http://search.twitter.com/search.json";
            string fullUrl = string.Format("{0}?q={1}&rpp=25&include_entities=true", url, query);

            if (!string.IsNullOrEmpty(search.ResultType))
            {
                fullUrl = string.Format("{0}&result_type={1}", fullUrl, search.ResultType);
            }

            if (search.GeoInfoCode != null && !string.IsNullOrEmpty(search.GeoInfoCode.Latitude))
            {
                fullUrl = string.Format("{0}&geocode={1}", fullUrl, search.GeoInfoCode.Code);
            }

            string signatureString = _oAuthCreationService.CreateSignature(url);
            string authorizationHeaderParams = _oAuthCreationService.CreateAuthorizationHeaderParameter(
                signatureString, _oAuthCreationService.OAuthTimeStamp);

            string method = "GET";
            HttpWebRequest request = _httpRequestResponse.GetRequest(fullUrl, authorizationHeaderParams, method);
            var responseText = _httpRequestResponse.GetResponse(request);
            var searchResponse = _mapSearch.Map(responseText);
            return searchResponse;
        }

        public TwitterSearchViewModel Initialize()
        {
            return new TwitterSearchViewModel
                       {
                           Latitude = "26.225948",
                           Until = DateTime.Now.AddHours(-1),
                           Longitude = "-80.188093",
                           Q = string.Empty,
                           ShowUser = true,
                           RadiusMiles = 100,
                           Rpp = 100,
                           ResultType = ResultType.Recent.TypeName

                       };
        }

        public IList<SearchResponse> GoSearch(TwitterSearchViewModel request)
        {
            var item = Mapper.Map<TwitterSearchViewModel, SearchRequest>(request);
            item.GeoInfoCode = new GeoInfo();
            item.GeoInfoCode = Mapper.Map<TwitterSearchViewModel, GeoInfo>(request);
            return Search(item);
        }
    }
}