namespace HappyVacation.Database.Entities.HotelBooking
{
    public class BookingDetail
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public int Quantity { get; set; }

        // navigation props
        public Booking Booking { get; set; }
        public Room Room { get; set; }
    }
}
