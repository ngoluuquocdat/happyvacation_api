namespace HappyVacation.DTOs.Orders
{
    public class OrderManageInfoVm
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; }
        public string DepartureDate { get; set; }
        public string OrderDate { get; set; }
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
        public string TouristName { get; set; }
        public string TouristPhone { get; set; }
        public string TouristEmail { get; set; }
    }
}
