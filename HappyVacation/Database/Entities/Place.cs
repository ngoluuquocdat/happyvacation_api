using HappyVacation.Database.Entities.HotelBooking;

namespace HappyVacation.Database.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public string PlaceName { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Description { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string OverviewVideoUrl { get; set; }

        // navigation props
        // 1 place - n tour places
        public List<TourPlace> TourPlaces { get; set; }
        // 1 place - n hotels
        public List<Hotel> Hotels { get; set; }
        // 1 place - n place images
        public List<PlaceImage> PlaceImages { get; set; }

        // 1 place - n tourist sites
        public List<SubTouristSite> SubTouristSites { get; set; }
    }
}
