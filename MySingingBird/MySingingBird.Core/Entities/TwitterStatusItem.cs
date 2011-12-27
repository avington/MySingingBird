using System;

namespace MySingingBird.Core.Entities
{
    public class TwitterStatusItem
    {
        public string InReplyToName { get; set; }
        public string InReplyToStatusId { get; set; }
        public string CreatedAt { get; set; }
        public string InReplyToUserId { get; set; }
        public StatusEntities Entities { get; set; }
        public TwitterUser User { get; set; }
        public string IdString { get; set; }
        public string Contributors { get; set; }
        public string Place { get; set; }
        public string Coordinates { get; set; }
        public string Source { get; set; }
        public string RetweetCount { get; set; }
        public bool Favorited { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }

        public bool Retweeted { get; set; }
    }
}