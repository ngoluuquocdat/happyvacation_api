using HappyVacation.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations
{
    public class ItineraryConfiguration : IEntityTypeConfiguration<Itinerary>
    {
        public void Configure(EntityTypeBuilder<Itinerary> builder)
        {
            builder.ToTable("Itineraries");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Content).IsRequired();

            // relationship config

            // 1-n: tour - itineraries
            builder.HasOne(itinerary => itinerary.Tour)
                .WithMany(tour => tour.Itineraries)
                .HasForeignKey(itinerary => itinerary.TourId);
        }
    }
}
