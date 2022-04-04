namespace HappyVacation.Database.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        // navigation props
        // 1 category - n tour categories
        public List<TourCategory> TourCategories { get; set; }
    }
}
