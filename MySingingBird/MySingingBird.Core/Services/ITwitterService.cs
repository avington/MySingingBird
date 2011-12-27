using MySingingBird.Core.Entities;
using MySingingBird.Entities;

namespace MySingingBird.Core.Services
{
    public interface ITwitterService
    {
        string RequestToken();
        TwitterUser GetUser(string screenName);
        TwitterFollowers GetFollowers(string screenName);
        TwitterFriends GetFriends(string screenName);
    }
}