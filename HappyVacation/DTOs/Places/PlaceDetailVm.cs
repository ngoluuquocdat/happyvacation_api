namespace HappyVacation.DTOs.Places
{
    public class PlaceDetailVm
    {
        public int Id { get; set; }
        public string PlaceName { get; set; }
        public string ThumbnailUrl { get; set; }
        public IEnumerable<string> Description { get; set; }    // list of paragraphs
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public IEnumerable<TravelTipVm> TravelTips { get; set; }
        public IEnumerable<PlaceImageVm> Images { get; set; }
        public string OverviewVideoUrl { get; set; }
        public int TourCount { get; set; }
        public int SubTouristSiteCount { get; set; }
    }
}
