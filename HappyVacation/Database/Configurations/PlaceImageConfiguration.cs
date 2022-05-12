using HappyVacation.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations
{
    public class PlaceImageConfiguration : IEntityTypeConfiguration<PlaceImage>
    {
        public void Configure(EntityTypeBuilder<PlaceImage> builder)
        {
            builder.ToTable("PlaceImages");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Url).IsRequired();

            // relationship config
            // 1-n: place - place images
            builder.HasOne(placeImage => placeImage.Place)
                .WithMany(place => place.PlaceImages)
                .HasForeignKey(placeImage => placeImage.PlaceId);
        }
    }
}
