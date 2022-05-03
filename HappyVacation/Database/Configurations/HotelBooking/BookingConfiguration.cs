using HappyVacation.Database.Entities.HotelBooking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations.HotelBooking
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.CustomerName).IsRequired().HasMaxLength(60);
            builder.Property(x => x.CustomerPhone).IsRequired().HasMaxLength(15);
            builder.Property(x => x.CustomerEmail).IsRequired().HasMaxLength(62);
            builder.Property(x => x.State).IsRequired().HasMaxLength(10);


            // relationship config

            // 1-n: hotel - hotel bookings
            builder.HasOne(booking => booking.Hotel)
                    .WithMany(hotel => hotel.Bookings)
                    .HasForeignKey(booking => booking.HotelId)
                    .OnDelete(DeleteBehavior.NoAction);

            // 1-n: user - hotel bookings
            builder.HasOne(booking => booking.User)
                    .WithMany(user => user.Bookings)
                    .HasForeignKey(booking => booking.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
