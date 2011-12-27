using System.Web.Mvc;
using MySingingBird.Core.Services;
using MySingingBird.Core.ViewModel;

namespace MySingingBird.Controllers
{
    public class SearchController : Controller
    {
        private readonly ITwitterSearchService _twitterSearchService;

        public SearchController(ITwitterSearchService twitterSearchService)
        {
            _twitterSearchService = twitterSearchService;
        }


        public ActionResult Index()
        {
            //var request = new SearchRequest();
            TwitterSearchViewModel requestViewModel = _twitterSearchService.Initialize();
            return View(requestViewModel);
        }

        [HttpPost]
        public ActionResult Go(TwitterSearchViewModel request)
        {
            var model = new SearchResultViewModel
                            {
                                Results = _twitterSearchService.GoSearch(request)
                            };

            return View("List", model);
        }

        public ActionResult test()
        {
            return View();
        }


    }
}