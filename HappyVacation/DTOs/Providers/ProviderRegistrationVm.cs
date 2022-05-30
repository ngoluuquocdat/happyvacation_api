namespace HappyVacation.DTOs.Providers
{
    public class ProviderRegistrationVm
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProviderName { get; set; }
        public string ContactPersonName { get; set; }
        public string ProviderEmail { get; set; }
        public string ProviderPhone { get; set; }
        public string DateCreated { get; set; }
        public bool IsApproved { get; set; }
    }
}
