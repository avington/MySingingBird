using System;
using System.Collections.Generic;
using System.Net;
using MySingingBird.Core.Entities;
using MySingingBird.Core.Http;
using MySingingBird.Core.Map;
using MySingingBird.Core.ViewModel;

namespace MySingingBird.Core.Services
{
    public class TwitterStatusService : ITwitterStatusService
    {
        private readonly IAnalyzeStatusesService _analyzeStatusesService;
        private readonly IHttpRequestResponse _httpRequestResponse;
        private readonly IMapStatus _mapStatus;
        private readonly IOAuthCreationService _oAuthCreationService;

        public TwitterStatusService(IHttpRequestResponse httpRequestResponse, IOAuthCreationService oAuthCreationService,
                                    IMapStatus mapStatus, IAnalyzeStatusesService analyzeStatusesService)
        {
            _httpRequestResponse = httpRequestResponse;
            _oAuthCreationService = oAuthCreationService;
            _mapStatus = mapStatus;
            _analyzeStatusesService = analyzeStatusesService;
        }

        #region ITwitterStatusService Members

        public TwitterStatusViewModel GetStatus(string userName)
        {
            /*
             * https://api.twitter.com/1/statuses/user_timeline.json?include_entities=true&include_rts=true&screen_name=twitterapi&count=200
             * */

            string url =
                string.Format(
                    @"https://api.twitter.com/1/statuses/user_timeline.json?include_entities=true&include_rts=true&screen_name={0}&count=200",
                    userName);
            string signatureString = _oAuthCreationService.CreateSignature(url);
            string authorizationHeaderParams = _oAuthCreationService.CreateAuthorizationHeaderParameter(
                signatureString, _oAuthCreationService.OAuthTimeStamp);

            string method = "GET";
            HttpWebRequest request = _httpRequestResponse.GetRequest(url, authorizationHeaderParams, method);
            string responseText = _httpRequestResponse.GetResponse(request);
            IList<TwitterStatusItem> response = _mapStatus.Map(responseText);
            var viewModel = _analyzeStatusesService.Anylize(response);
            return viewModel;
        }

        #endregion
    }
}