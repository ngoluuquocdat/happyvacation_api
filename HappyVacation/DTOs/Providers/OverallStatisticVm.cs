namespace HappyVacation.DTOs.Providers
{
    public class OverallStatisticVm
    {
        public int TotalTourCount { get; set; }
        public List<string> MainCategories { get; set; }
        public List<string> MainPlaces { get; set; }
        public int TotalOrderCount { get; set; }
        public int ConfirmedOrderCount { get; set; }
        public int CanceledOrderCount { get; set; }
    }
}
