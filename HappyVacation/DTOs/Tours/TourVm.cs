using HappyVacation.DTOs.Places;

namespace HappyVacation.DTOs.Tours
{
    public class TourVm
    {
        public int Id { get; set; }
        public string TourName { get; set; }
        public string Overview { get; set; }
        public float Duration { get; set; }
        public int GroupSize { get; set; }
        public int MinAdults { get; set; }       
        public string StartTime { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderAvatar { get; set; }
        public IEnumerable<PlaceVm> Places { get; set; }
        public IEnumerable<CategoryVm> Categories{ get; set; }
        public IEnumerable<ItineraryVm> Itineraries { get; set; }
        public IEnumerable<ExpenseVm> Expenses { get; set; }
        public IEnumerable<ImageVm> Images { get; set; }
        public int PricePerAdult { get; set; }
        public int PricePerChild { get; set; }
        public bool IsPrivate { get; set; }
        public int Reviews { get; set; }
        public float Rating { get; set; }
    }
}
