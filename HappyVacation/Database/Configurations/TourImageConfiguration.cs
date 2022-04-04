using HappyVacation.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations
{
    public class TourImageConfiguration : IEntityTypeConfiguration<TourImage>
    {
        public void Configure(EntityTypeBuilder<TourImage> builder)
        {
            builder.ToTable("TourImages");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Url).IsRequired();

            // relationship config

            // 1-n: tour - tour images
            builder.HasOne(tourImage => tourImage.Tour)
                .WithMany(tour => tour.TourImages)
                .HasForeignKey(tourImage => tourImage.TourId);

        }
    }
}
