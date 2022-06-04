namespace HappyVacation.DTOs.Orders
{
    // list of tourists from orders for same tour and same departure date
    public class OrderedTouristCollect
    {
        public int TourId { get; set; }
        public string TourName { get; set; }
        public string DepartureDate { get; set; }
        public List<OrderedTourists> TouristGroups { get; set; }    // tourist groups by order ids
        public int TotalCount { get; set; }
        public string ExportFilePath { get; set; }
    }
}
