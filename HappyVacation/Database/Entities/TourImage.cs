namespace HappyVacation.Database.Entities
{
    public class TourImage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int TourId { get; set; }

        // navigation props
        // 1 tour - n tour images
        public Tour Tour { get; set; }
    }
}
