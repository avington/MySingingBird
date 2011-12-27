using MySingingBird.Core.Entities;
using MySingingBird.Entities;

namespace MySingingBird.Core.Map
{
    public interface IMapUser
    {
        TwitterUser MapProfileInfo(string jsonResponse);
        TwitterFollowers MapFollowers(string jsonResponse);
        TwitterFriends MapFriends(string jsonResponse);
    }
}