using System.Collections.Generic;
using System.Web.Mvc;
using MySingingBird.Core.Entities;
using MySingingBird.Core.Services;

namespace MySingingBird.Controllers
{
    public class GeoController : Controller
    {
        private readonly ITwitterSearchService _twitterSearchService;

        public GeoController(ITwitterSearchService twitterSearchService)
        {
            _twitterSearchService = twitterSearchService;
        }

        public ActionResult Index()
        {
            var search = new SearchRequest
                             {
                                 GeoInfoCode = new GeoInfo
                                                   {
                                                       Latitude = "-80.19084",
                                                       Longitude = "26.209278",
                                                       RadiusMiles = 10
                                                   }
                                 ,
                                 Q = "grace",
                                 ResultType = "recent"
                             };

            IList<SearchResponse> geo = _twitterSearchService.Search(search);
            return View(geo);
        }

    }
}