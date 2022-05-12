using HappyVacation.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations
{
    public class SubTouristSiteConfiguration : IEntityTypeConfiguration<SubTouristSite>
    {
        public void Configure(EntityTypeBuilder<SubTouristSite> builder)
        {
            builder.ToTable("SubTouristSites");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Latitude).HasPrecision(18, 9);
            builder.Property(x => x.Longitude).HasPrecision(18, 9);

            // relationship config
            // 1-n: place - sub tourist sites
            builder.HasOne(subTouristSite => subTouristSite.Place)
                .WithMany(place => place.SubTouristSites)
                .HasForeignKey(subTouristSite => subTouristSite.PlaceId);
        }
    }
}
