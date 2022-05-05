namespace HappyVacation.DTOs.Orders
{
    public class OrderMainInfoVm
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; }
        public string DepartureDate { get; set; }
        public string ModifiedDate { get; set; }
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
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
    }
}
