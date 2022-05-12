namespace HappyVacation.DTOs.Places
{
    public class TouristSiteVm
    {
        public int Id { get; set; }
        public string SiteName { get; set; }
        public IEnumerable<string> Description { get; set; } // list of paragraphs
        public IEnumerable<string> HighLights { get; set; }  // list of paragraphs seperate by '|'      
        public string Address { get; set; }
        public string OpenCloseTime { get; set; }   // Ex: 9:00 AM - 10:30 PM
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public IEnumerable<TouristSiteImageVm> Images { get; set; }
    }
}
