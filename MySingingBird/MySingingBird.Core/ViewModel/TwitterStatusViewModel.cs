using System.Collections.Generic;

namespace MySingingBird.Core.ViewModel
{
    public class TwitterStatusViewModel
    {
        public decimal PercentReplies { get; set; }
        public string PercentRepliesFormatted { get; set; }
        public decimal PercentRetweeted { get; set; }
        public string PercentRetweetedFormated { get; set; }
        public List<string> UsersReplied { get; set; }

        public string UserScreenName { get; set; }

        public string UserScreenImage { get; set; }

        public int TotalTweetsAnalyzed { get; set; }

        public string FollowerCount { get; set; }

        public string FreindCount { get; set; }
    }
}