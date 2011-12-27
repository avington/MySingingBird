namespace MySingingBird.Core.Entities
{
    public class SearchResponse
    {
        public string FromUserName { get; set; }
        public string FromUserId { get; set; }
        public string FromLocation { get; set; }
        public string FromProfileImage { get; set; }
        public string Text { get; set; }
        public string ToUserName { get; set; }
        public string ToUserId { get; set; }
        public string ToLocation { get; set; }
        public string ToProfileImage { get; set; }
        
    }
}