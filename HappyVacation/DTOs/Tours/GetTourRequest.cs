namespace HappyVacation.DTOs.Tours
{
    public class GetTourRequest
    {
        public int PlaceId { get; set; }
        public bool PrivateOnly { get; set; }
        public string? Keyword { get; set; }
        public int Duration { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public List<int>? CategoryIds { get; set; }
        public bool MatchAll { get; set; }
        public string? Sort { get; set; }
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 10;
    }
}
