namespace HappyVacation.Database.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public string PlaceName { get; set; }
        public string ThumbnailUrl { get; set; }
        public bool IsTop { get; set; }

        // navigation props
        // 1 place - n tours
        public List<Tour> Tours { get; set; }
    }
}
