namespace HappyVacation.DTOs.Orders
{
    public class CreateTourOrderRequest
    {
        public int TourId { get; set; }
        public string DepartureDate { get; set; }   // dd/MM/yyyy
        public int Adults { get; set; }
        public List<AdultDTO> AdultsList { get; set; }
        public int Children { get; set; }
        public List<ChildDTO> ChildrenList { get; set; }
        public string TouristName { get; set; }
        public string TouristPhone { get; set; }
        public string TouristEmail { get; set; }
        public string? StartPoint { get; set; }
        public string? EndPoint { get; set; }
    }
}
