namespace HappyVacation.Database.Entities
{
    public class SubTouristSite
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public string Description { get; set; }
        public string HighLights { get; set; }  // seperate by '&'
        public string Province { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string Address { get; set; }
        public string OpenCloseTime { get; set; }   // Ex: 9:00 AM - 10:30 PM
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public int PlaceId { get; set; }

        // navigation props
        // 1 place - n tourist sites
        public Place Place { get; set; }
        // 1 tourist site - n tourist site image
        public List<SubTouristSiteImage> SubTouristSiteImages { get; set; }
    }
}
