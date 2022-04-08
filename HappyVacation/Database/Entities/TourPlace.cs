namespace HappyVacation.Database.Entities
{
    public class TourPlace
    {
        public int TourId { get; set; }
        public int PlaceId { get; set; }

        // navigation props
        // 1 tour - n tour categories
        public Tour Tour { get; set; }
        // 1 place - n tour places
        public Place Place { get; set; }
    }
}
