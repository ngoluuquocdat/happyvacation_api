using HappyVacation.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations
{
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.ToTable("Places");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.PlaceName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.ThumbnailUrl).IsRequired();

            builder.Property(x => x.Latitude).HasPrecision(18, 9);
            builder.Property(x => x.Longitude).HasPrecision(18, 9);

        }
    }
}
