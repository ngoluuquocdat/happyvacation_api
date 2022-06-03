namespace HappyVacation.DTOs.Providers.ProviderManage
{
    public class ProviderManageDetailVm
    {
        public int Id { get; set; }
        public string OwnerUsername { get; set; }
        public string OwnerFullName { get; set; }
        public string ProviderName { get; set; }
        public string ProviderPhone { get; set; }
        public string ProviderEmail { get; set; }
        public string Address { get; set; }
        public string DateCreated { get; set; }
        public float AverageRating { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }

        public int TotalTourCount { get; set; }
        public int TotalOrderCount { get; set; }
        public int ConfirmedOrderCount { get; set; }
        public int CanceledOrderCount { get; set; }

        public List<string> TopCategories { get; set; }
    }
}
