namespace HappyVacation.DTOs.Providers.ProviderManage
{
    public class GetProvidersManageRequest
    {
        public int ProviderId { get; set; }
        public string? Keyword { get; set; }     // provider name, provider phone or provider email
        public int OwnerId { get; set; }
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 4;
    }
}
