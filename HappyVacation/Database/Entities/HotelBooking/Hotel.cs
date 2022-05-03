namespace HappyVacation.Database.Entities.HotelBooking
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string Address { get; set; }
        public int MinChildAge { get; set; }
        public int Stars { get; set; }
        public bool HasParkingLot { get; set; }
        public bool HasBreakfast { get; set; }
        public bool PetAllowed { get; set; }
        // cancel - booking policy
        public bool CreditCardRequired { get; set; }
        public bool PayInAdvance { get; set; }
        //public bool CancellationPenalty { get; set; }
        public string Note { get; set; }
        public int PlaceId { get; set; }

        // navigation props
        // 1 place - n hotels
        public Place Place { get; set; }
        // 1 hotel - 1 user
        public User User { get; set; }
        // 1 hotel - n rooms
        public List<Room> Rooms { get; set; }
        // 1 hotel - n bookings
        public List<Booking> Bookings { get; set; }
    }
}
