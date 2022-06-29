namespace HappyVacation.Database.Entities
{
    public class ProviderRegistration
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProviderName { get; set; }
        public string ContactPersonName { get; set; }
        public string ProviderEmail { get; set; }
        public string ProviderPhone { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }

        // navigation props
        // 1 provider registration - 1 user
        public User User { get; set; }
    }
}
