using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySingingBird.Core.Services;
using MySingingBird.Core.ViewModel;

namespace MySingingBird.Controllers
{
    public class StatusController : Controller
    {
        private readonly TwitterStatusService _twitterStatusService;

        public StatusController(TwitterStatusService twitterStatusService)
        {
            _twitterStatusService = twitterStatusService;
        }

        public ActionResult Index(string userName)
        {

            TwitterStatusViewModel model = _twitterStatusService.GetStatus(userName);
            return View(model);
        }

    }
}
