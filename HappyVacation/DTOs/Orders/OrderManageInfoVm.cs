namespace HappyVacation.DTOs.Orders
{
    public class OrderManageInfoVm
    {
        public int Id { get; set; }
        public string TourName { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public float Duration { get; set; }
        public bool IsPrivate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int PricePerAdult { get; set; }
        public int PricePerChild { get; set; }
        public int TotalPrice { get; set; }
        public string ThumbnailUrl { get; set; }
        public string State { get; set; }
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }




        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarUrl { get; set; }
    }
}
