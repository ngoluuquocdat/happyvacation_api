namespace HappyVacation.Database.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public float Rating { get; set; }
        public int UserId { get; set; }
        public int TourId { get; set; }

        // navigation props
        // 1 tour - n reviews
        public Tour Tour { get; set; }
        // 1 user - n reviews
        public User User { get; set; }
    }
}
