namespace HappyVacation.DTOs.Users
{
    public class WishItemVm
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; }
        public string ThumbnailPath { get; set; }
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderAvatar { get; set; }
    }
}
