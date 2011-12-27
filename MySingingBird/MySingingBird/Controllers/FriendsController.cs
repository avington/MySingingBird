using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySingingBird.Core.Services;

namespace MySingingBird.Controllers
{
    public class FriendsController : Controller
    {
        private readonly ITwitterService _twitterService;
        private readonly IWhosNotFollowing _whosNotFollowing;

        public FriendsController(ITwitterService twitterService, IWhosNotFollowing whosNotFollowing)
        {
            _twitterService = twitterService;
            _whosNotFollowing = whosNotFollowing;
        }

        public ActionResult Index()
        {
            var response = _twitterService.GetUser("siravington");
            var followers = _twitterService.GetFollowers("siravington");
            var friends = _twitterService.GetFriends("siravington");
            var notFollowing = _whosNotFollowing.Validate(friends, followers);
            return View();
        }

    }
}
