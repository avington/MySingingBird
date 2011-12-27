using System;

namespace MySingingBird.Entities
{
    public class ProfileStatus
    {
        public string Place { get; set; }
        public int RetweetCount { get; set; }
        public string InReplyToScreenName { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRetweeted { get; set; }
        public string IdString { get; set; }
        public string Source { get; set; }
        public bool IsFavorated { get; set; }
        public string Id { get; set; }

    }
}