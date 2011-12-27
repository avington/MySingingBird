using System.Collections.Generic;
using System.Web.Script.Serialization;
using MySingingBird.Core.Entities;
using MySingingBird.Entities;

namespace MySingingBird.Core.Map
{
    public class MapUser : IMapUser
    {
        public TwitterUser MapProfileInfo(string jsonResponse)
        {
            var jss = new JavaScriptSerializer();
            var data = jss.Deserialize<dynamic>(jsonResponse);
            if (data != null && data[0] != null)
            {
                var d = data[0];
                TwitterUser user = new TwitterUser();
                user.IdString = d["id_str"];
                user.Description = d["description"];
                user.Name = d["name"];
                user.ScreenName = d["screen_name"];
                return user;
            }
            return null;
        }

        public TwitterFollowers MapFollowers(string jsonResponse)
        {
            var jss = new JavaScriptSerializer();
            var data = jss.Deserialize<dynamic>(jsonResponse);
            if (data != null )
            {
                TwitterFollowers user = new TwitterFollowers();
                user.PreviousCursor =  data["next_cursor"];
                foreach (dynamic id in data["ids"])
                {
                    if (user.Ids == null) user.Ids = new List<long>();
                    user.Ids.Add(id);
                }
                return user;
            }
            return null;
        }

        public TwitterFriends MapFriends(string jsonResponse)
        {
            var jss = new JavaScriptSerializer();
            var data = jss.Deserialize<dynamic>(jsonResponse);
            if (data != null)
            {
                var user = new TwitterFriends();
                user.PreviousCursor = data["next_cursor"];
                foreach (dynamic id in data["ids"])
                {
                    if (user.Ids == null) user.Ids = new List<long>();
                    user.Ids.Add(id);
                }
                return user;
            }
            return null;
        }
    }
}