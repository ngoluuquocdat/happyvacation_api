using HappyVacation.Database.Entities.HotelBooking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations.HotelBooking
{
    public class BookingDetailConfiguration : IEntityTypeConfiguration<BookingDetail>
    {
        public void Configure(EntityTypeBuilder<BookingDetail> builder)
        {
            builder.ToTable("BookingDetails");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();



            // relationship config

            // 1-n: booking - booking details
            builder.HasOne(bookingDetail => bookingDetail.Booking)
                    .WithMany(booking => booking.BookingDetails)
                    .HasForeignKey(bookingDetail => bookingDetail.BookingId)
                    .OnDelete(DeleteBehavior.NoAction);

            // 1-n: room - booking details
            builder.HasOne(bookingDetail => bookingDetail.Room)
                    .WithMany(room => room.BookingDetails)
                    .HasForeignKey(bookingDetail => bookingDetail.RoomId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
