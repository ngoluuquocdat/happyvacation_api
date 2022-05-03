namespace HappyVacation.Database.Entities.HotelBooking
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxAdults { get; set; }
        public int Area { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public string Views { get; set; }
        public bool SmokingAllowed { get; set; }
        public int HotelId { get; set; }

        // navigation props
        // 1 hotel - n rooms
        public Hotel Hotel { get; set; }
        // 1 tour - n booking details
        public List<BookingDetail> BookingDetails { get; set; }
    }
}
