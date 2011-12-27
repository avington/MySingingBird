namespace MySingingBird.Core.Entities
{
    public class GeoInfo
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int RadiusMiles { get; set; }
        public string Code
        {
            get { return string.Format("{0},{1},{2}mi", Latitude, Longitude, RadiusMiles.ToString()); }
        }
    }
}