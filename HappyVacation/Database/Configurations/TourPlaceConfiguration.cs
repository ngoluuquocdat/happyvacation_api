using HappyVacation.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations
{
    public class TourPlaceConfiguration : IEntityTypeConfiguration<TourPlace>
    {
        public void Configure(EntityTypeBuilder<TourPlace> builder)
        {
            builder.ToTable("TourPlaces");

            // composite key
            builder.HasKey(x => new { x.TourId, x.PlaceId });

            // relationship config

            // 1-n: tour - tour places
            builder.HasOne(tourPlace => tourPlace.Tour)
                .WithMany(tour => tour.TourPlaces)
                .HasForeignKey(tourPlace => tourPlace.TourId);
            // 1-n: place - tour places
            builder.HasOne(tourPlace => tourPlace.Place)
                .WithMany(place => place.TourPlaces)
                .HasForeignKey(tourPlace => tourPlace.PlaceId);
        }
    }
}
