using System;
using System.Collections.Generic;
using System.Linq;
using MySingingBird.Core.Entities;
using System.Globalization;
using MySingingBird.Core.Helpers;
using MySingingBird.Core.ViewModel;

namespace MySingingBird.Core.Services
{
    public class AnalyzeStatusesService : IAnalyzeStatusesService
    {
        private readonly IMathService _mathService;

        public AnalyzeStatusesService(IMathService mathService)
        {
            _mathService = mathService;
        }

        public TwitterStatusViewModel Anylize(IList<TwitterStatusItem> response)
        {
            if (response == null) return new TwitterStatusViewModel();
            int totalTweets = response.Count;
            decimal replies = 0;
            decimal retweets = 0;
            var usersMentioned = new List<string>();
            string screenName="";
            string userImage = "";
            string followerCount = "";
            string friendCount = "";
            foreach (var item in response)
            {
                if (!string.IsNullOrEmpty(item.InReplyToName))
                {
                    replies++;
                    usersMentioned.Add(item.InReplyToName);
                }
                if (item.Retweeted)
                {
                    retweets++;
                }
                screenName = item.With(x => x.User).With(x => x.ScreenName);
                userImage = item.With(x => x.User).With(x => x.ProfileImageUrl);
                followerCount = item.Return(x => x.User, new TwitterUser()).Following.ToString();
                friendCount = item.Return(x => x.User,new TwitterUser()).ProfileFriendCount.ToString();

            }

            var percentReplies = _mathService.CalculatePercent(replies, totalTweets);
            var percentRetweets = _mathService.CalculatePercent(retweets, totalTweets);

            return new TwitterStatusViewModel
                       {
                           PercentReplies = percentReplies,
                           PercentRepliesFormatted = percentReplies.ToString("p1"),
                           PercentRetweeted = percentRetweets,
                           PercentRetweetedFormated = percentRetweets.ToString("p1"),
                           UsersReplied = usersMentioned.Distinct().ToList(),
                           UserScreenName = screenName ?? "",
                           UserScreenImage = userImage ?? "",
                           FollowerCount = followerCount,
                           FreindCount = friendCount,
                           TotalTweetsAnalyzed = totalTweets,

                       };

        }


    }
}