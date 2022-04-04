namespace HappyVacation.Database.Entities
{
    public class Itinerary
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int TourId { get; set; }

        // navigation props
        // 1 tour - n itinerary items
        public Tour Tour { get; set; }
    }
}
