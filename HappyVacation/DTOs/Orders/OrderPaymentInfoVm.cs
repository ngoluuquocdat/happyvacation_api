namespace HappyVacation.DTOs.Orders
{
    public class OrderPaymentInfoVm
    {
        public int OrderId { get; set; }
        public string TourName { get; set; }
        public string ProviderName { get; set; }
        public int TotalPrice { get; set; }
    }
}
