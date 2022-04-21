namespace HappyVacation.DTOs.Tours
{
    public class GetTourManageRequest
    {
        public int TourId { get; set; }
        public string? TourName { get; set; }
        public List<int>? PlaceIds { get; set; }
        public List<int>? CategoryIds { get; set; }
        public string? Sort { get; set; }
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 4;
    }
}
