using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using MySingingBird.Core.Entities;

namespace MySingingBird.Core.Map
{
    public class MapStatus : IMapStatus
    {
        public IList<TwitterStatusItem> Map(string jsonResponse)
        {
            var list = new List<TwitterStatusItem>();
            var jss = new JavaScriptSerializer();
            var data = jss.Deserialize<dynamic>(jsonResponse);

            foreach (dynamic item in data)
            {
                if (item == null) continue;
                var dictionary = (Dictionary<string, object>) item;
                var tweet = new TwitterStatusItem();
                if (dictionary.ContainsKey("in_reply_to_screen_name"))
                {
                    tweet.InReplyToName = item["in_reply_to_screen_name"];
                    tweet.InReplyToStatusId = item["in_reply_to_status_id_str"];
                    tweet.InReplyToUserId = item["in_reply_to_user_id_str"];
                    //tweet.RetweetCount = item["retweet_count"];
                    tweet.Favorited = item["favorited"];
                    tweet.Text = item["text"];
                    tweet.CreatedAt = item["created_at"];
                    tweet.Retweeted = item["retweeted"];
                    if (dictionary.ContainsKey("user"))
                    {
                        tweet.User = new TwitterUser();
                        tweet.User.ScreenName = item["user"]["screen_name"];
                        tweet.User.ProfileImageUrl = item["user"]["profile_image_url"];
                        tweet.User.Following = item["user"]["followers_count"];
                        tweet.User.ProfileFriendCount = item["user"]["friends_count"];
                    }
                }

                list.Add(tweet);
            }
            return list;
        }

        
    }
}