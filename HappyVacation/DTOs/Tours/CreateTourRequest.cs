namespace HappyVacation.DTOs.Tours
{
    public class CreateTourRequest
    {
        public string TourName { get; set; }
        public string Overview { get; set; }
        public bool IsPrivate { get; set; }
        public float Duration { get; set; }
        public int GroupSize { get; set; }
        public int MinAdults { get; set; }
        public int PricePerAdult { get; set; }
        public int PricePerChild { get; set; }
        public bool IncludeChildren { get; set; }
        public string Location { get; set; }
        public string Destination { get; set; }
        public List<int> PlaceIds { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<ItineraryVm> Itineraries { get; set; }
        public List<ExpenseVm> Expenses { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
