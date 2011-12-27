using System.Collections.Generic;

namespace MySingingBird.Core.Entities
{
    public class StatusEntities
    {
        public TwitterUser UserMentions { get; set; }
        public IList<string> Urls { get; set; }
        public IList<string> HashTags { get; set; }
    }
}