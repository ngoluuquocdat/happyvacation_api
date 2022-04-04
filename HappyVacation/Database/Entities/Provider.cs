namespace HappyVacation.Database.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string ProviderName { get; set; }
        public string ProviderPhone { get; set; }
        public string ProviderEmail { get; set; }
        public DateTime DateCreated { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public bool IsEnabled { get; set; }

        // navigation props
        // 1 provider - 1 user
        public User User { get; set; }
        // 1 provider - n tours
        public List<Tour> Tours { get; set; }
        // 1 tour - n orders
        public List<Order> Orders { get; set; }
    }

}
