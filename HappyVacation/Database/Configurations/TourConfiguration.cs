using HappyVacation.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations
{
    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.ToTable("Tours");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.TourName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Overview).IsRequired();
            builder.Property(x => x.Location).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Destination).IsRequired().HasMaxLength(100);

            // relationship config
            // 1-n: provider - tours
            builder.HasOne(tour => tour.Provider)
                .WithMany(provider => provider.Tours)
                .HasForeignKey(tour => tour.ProviderId);
        }
    }
}
