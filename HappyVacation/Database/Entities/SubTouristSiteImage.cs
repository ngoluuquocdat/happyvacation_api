namespace HappyVacation.Database.Entities
{
    public class SubTouristSiteImage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int SubTouristSiteId { get; set; }

        // navigation props
        // 1 tourist site - n tourist site images
        public SubTouristSite SubTouristSite { get; set; }
    }
}
