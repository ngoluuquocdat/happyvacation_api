using HappyVacation.Database.Configurations;
using HappyVacation.Database.Configurations.HotelBooking;
using HappyVacation.Database.Entities;
using HappyVacation.Database.Entities.HotelBooking;
using HappyVacation.Database.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HappyVacation.Database
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure using Fluent API

            // configuration for tour booking
            modelBuilder.ApplyConfiguration(new PlaceConfiguration());
            modelBuilder.ApplyConfiguration(new TourPlaceConfiguration());
            modelBuilder.ApplyConfiguration(new PlaceImageConfiguration());
            modelBuilder.ApplyConfiguration(new SubTouristSiteConfiguration());
            modelBuilder.ApplyConfiguration(new SubTouristSiteImageConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TourCategoryConfiguration());

            modelBuilder.ApplyConfiguration(new TourConfiguration());
            modelBuilder.ApplyConfiguration(new ItineraryConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new TourImageConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());

            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            // configuration for hotel booking
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new BookingDetailConfiguration());

            // Data seeding
            modelBuilder.Seed();
        }

        // place and tourist sites
        public DbSet<Place> Places { get; set; }
        public DbSet<SubTouristSite> SubTouristSites { get; set; }
        // ...
        // ------------------------------------
        public DbSet<Category> Categories { get; set; }
        public DbSet<TourCategory> TourCategories { get; set; }
        public DbSet<TourPlace> TourPlaces { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<TourImage> TourImages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        // hotel booking
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
    }
}
