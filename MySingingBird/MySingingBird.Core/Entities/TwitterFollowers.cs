using System.Collections.Generic;

namespace MySingingBird.Core.Entities
{
    public class TwitterFollowers
    {
        public int NextCursor { get; set; }
        public List<long> Ids { get; set; }
        public int PreviousCursor { get; set; }
    }
}