using System;
using MySingingBird.Core.Entities;

namespace MySingingBird.Core.ViewModel
{
    public class TwitterSearchViewModel
    {
        public string Q { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int RadiusMiles { get; set; }
        public string ResultType { get; set; }
        public int? Rpp { get; set; }
        public bool? ShowUser { get; set; }
        public DateTime? Until { get; set; }
    }
}