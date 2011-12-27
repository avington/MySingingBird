using System;

namespace MySingingBird.Core.Entities
{
    public class SearchRequest
    {
        public string Q { get; set; }
        public GeoInfo GeoInfoCode { get; set; }
        public string ResultType { get; set; }
        public int? Rpp { get; set; }
        public bool? ShowUser { get; set; }
        public DateTime? Until { get; set; }
        public string FormattedUntil
        {
            get
            {
                return Until.HasValue ? Until.Value.ToString("yyyyy-MM-dd") : string.Empty;
            }
        }
    }
}