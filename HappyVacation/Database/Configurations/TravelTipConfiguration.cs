using HappyVacation.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations
{
    public class TravelTipConfiguration : IEntityTypeConfiguration<TravelTip>
    {
        public void Configure(EntityTypeBuilder<TravelTip> builder)
        {
            builder.ToTable("TravelTips");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Content).IsRequired();

            // relationship config
            // 1-n: place - travel tips
            builder.HasOne(travelTip => travelTip.Place)
                .WithMany(place => place.TravelTips)
                .HasForeignKey(travelTip => travelTip.PlaceId);
        }
    }
}
