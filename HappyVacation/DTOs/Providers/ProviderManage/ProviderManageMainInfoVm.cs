namespace HappyVacation.DTOs.Providers.ProviderManage
{
    public class ProviderManageMainInfoVm
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProviderName { get; set; }
        public string DateCreated { get; set; }
        public string AvatarUrl { get; set; }
        public float AverageRating { get; set; }
        public bool IsEnabled { get; set; }
    }
}
