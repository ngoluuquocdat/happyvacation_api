namespace HappyVacation.Database.Entities
{
    public class TourCategory
    {
        public int TourId { get; set; }
        public int CategoryId { get; set; }

        // navigation props
        // 1 tour - n tour categories
        public Tour Tour { get; set; }
        // 1 category - n tour categories
        public Category Category { get; set; }
    }
}
