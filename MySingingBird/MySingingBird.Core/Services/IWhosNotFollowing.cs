using MySingingBird.Core.Entities;

namespace MySingingBird.Core.Services
{
    public interface IWhosNotFollowing
    {
        TwitterFollowers Validate(TwitterFriends friends, TwitterFollowers followers);
    }
}