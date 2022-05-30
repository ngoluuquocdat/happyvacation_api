namespace HappyVacation.DTOs.Providers
{
    public class GetProviderRegistrationRequest
    {
        public int RegistrationId { get; set; }
        public string? ProviderName { get; set; }
        public string? ContactPersonName { get; set; }
        public string? ProviderEmail { get; set; }
        public string? ProviderPhone { get; set; }
        //public string? Sort { get; set; }
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 4;
    }
}
