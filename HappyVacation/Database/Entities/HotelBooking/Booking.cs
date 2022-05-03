namespace HappyVacation.Database.Entities.HotelBooking
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string State { get; set; }
        public string? CancelReason { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public int HotelId { get; set; }
        public int UserId { get; set; }

        // navigation props
        public User User { get; set; }
        public Hotel Hotel { get; set; }
        public List<BookingDetail> BookingDetails { get; set; }
    }
}
