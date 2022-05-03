using HappyVacation.Database.Entities.HotelBooking;

namespace HappyVacation.Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? AvatarUrl { get; set; }
        // null if this user is not a tour provider owner
        public int? ProviderId { get; set; }
        // null if this user is not a hotel owner
        public int? HotelId { get; set; }
        public bool IsEnabled { get; set; }

        // navigation props
        // 1 tour provider - 1 user
        public Provider Provider { get; set; }
        // 1 hotel - 1 user
        public Hotel Hotel { get; set; }
        // 1 user - n user roles
        public List<UserRole> UserRoles { get; set; }
        // 1 user - n reviews
        public List<Review> Reviews { get; set; }
        // 1 user - n tour orders
        public List<Order> Orders { get; set; }
        // 1 user - n hotel bookings
        public List<Booking> Bookings { get; set; }
    }
}
