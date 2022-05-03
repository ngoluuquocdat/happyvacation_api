namespace HappyVacation.DTOs.Hotels
{
    public class GetHotelRequest
    {
        public int PlaceId { get; set; }
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public int Adults { get; set; }
        public List<int>? Children { get; set; }
        public int Rooms { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string? Keyword { get; set; }
        public string? Sort { get; set; }
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 10;
    }
}
