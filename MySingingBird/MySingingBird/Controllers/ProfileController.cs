using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySingingBird.Core.Services;
using MySingingBird.Core.ViewModel;

namespace MySingingBird.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ITwitterStatusService _twitterStatusService;

        public ProfileController(ITwitterStatusService twitterStatusService)
        {
            _twitterStatusService = twitterStatusService;
        }

        public ActionResult Index(string id)
        {
            TwitterStatusViewModel response = _twitterStatusService.GetStatus(id);
            return View(response);
        }

        [HttpGet]
        public JsonResult Analyze(string id)
        {
            TwitterStatusViewModel response = _twitterStatusService.GetStatus(id);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Follow(string id)
        {
            throw new NotImplementedException();
        }
    }
}
