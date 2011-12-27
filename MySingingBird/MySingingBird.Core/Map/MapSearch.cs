using System.Collections.Generic;
using System.Web.Script.Serialization;
using MySingingBird.Core.Entities;

namespace MySingingBird.Core.Map
{
    public class MapSearch : IMapSearch
    {
        #region IMapSearch Members

        public IList<SearchResponse> Map(string jsonResponse)
        {
            var list = new List<SearchResponse>();
            var jss = new JavaScriptSerializer();
            var data = jss.Deserialize<dynamic>(jsonResponse);
            if (data != null && data["results"] != null)
            {
                foreach (dynamic item in data["results"])
                {
                    if (item == null) continue;
                    var result = new SearchResponse();
                    var d = (Dictionary<string, object>) item;
                    result.FromLocation = d.ContainsKey("location") ? item["location"] : "";
                    result.FromProfileImage = item["profile_image_url"];
                    result.FromUserId = item["from_user_id_str"];
                    result.FromUserName = item["from_user"];
                    result.Text = item["text"];
                    list.Add(result);
                }
                return list;
            }
            return null;
        }

        #endregion
    }
}