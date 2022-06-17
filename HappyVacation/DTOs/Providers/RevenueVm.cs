using HappyVacation.DTOs.Places;
using HappyVacation.DTOs.Tours;

namespace HappyVacation.DTOs.Providers
{
    public class RevenueVm
    {
        public List<string> MonthLabels { get; set; }
        public List<int> Revenue { get; set; }
        public int TotalOrderCount { get; set; }
        public int ConfirmedOrderCount { get; set; }
        public int CanceledOrderCount { get; set; }
        public List<CategoryVm> TopOrderedCategories { get; set; }
        public List<PlaceVm> TopOrderedPlaces { get; set; }
        public List<TourStatisticVm> TopOrderedTours { get; set; }
    }
}
