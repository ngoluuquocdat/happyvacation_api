namespace HappyVacation.DTOs.Tours
{
    public class TourStatisticVm
    {
        public int TourId { get; set; }
        public string TourName { get; set; }
        public int TotalOrderCount { get; set; }
        public int ConfirmedOrderCount { get; set; }
        public int CanceledOrderCount { get; set; }
    }
}
