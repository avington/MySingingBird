using System.Collections.Generic;
using MySingingBird.Core.Entities;

namespace MySingingBird.Core.Services
{
    public class WhosNotFollowing : IWhosNotFollowing
    {
        public TwitterFollowers Validate(TwitterFriends friends, TwitterFollowers followers)
        {
            var notFollowing = new TwitterFollowers {Ids = new List<long>()};
            foreach (var id in followers.Ids)
            {
                bool isFollowing = false;
                foreach (var friend in friends.Ids)
                {
                    if (friend == id)
                        isFollowing = true;
                }  
                if (! isFollowing) notFollowing.Ids.Add(id);
            }
            return notFollowing;
        }
    }
}