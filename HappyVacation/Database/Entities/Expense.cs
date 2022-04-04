namespace HappyVacation.Database.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsIncluded { get; set; }
        public int TourId { get; set; }

        // navigation props
        // 1 tour - n expenses
        public Tour Tour { get; set; }
    }
}
