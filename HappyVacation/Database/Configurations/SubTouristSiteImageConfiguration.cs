using HappyVacation.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations
{
    public class SubTouristSiteImageConfiguration : IEntityTypeConfiguration<SubTouristSiteImage>
    {
        public void Configure(EntityTypeBuilder<SubTouristSiteImage> builder)
        {
            builder.ToTable("TouristSiteImages");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Url).IsRequired();

            // relationship config
            // 1-n: sub tourist site - sub tourist site images
            builder.HasOne(subTouristSiteImage => subTouristSiteImage.SubTouristSite)
                .WithMany(SubTouristSite => SubTouristSite.SubTouristSiteImages)
                .HasForeignKey(subTouristSiteImage => subTouristSiteImage.SubTouristSiteId);
        }
    }
}
