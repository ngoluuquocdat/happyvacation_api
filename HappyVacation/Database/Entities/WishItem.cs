namespace HappyVacation.Database.Entities
{
    public class WishItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TourId { get; set; }
        public DateTime Date { get; set; }

        // navigation props
        public User User { get; set; }
        public Tour Tour { get; set; }
    }
}
