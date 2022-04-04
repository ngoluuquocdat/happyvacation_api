using HappyVacation.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.TouristName).IsRequired().HasMaxLength(60);
            builder.Property(x => x.TouristPhone).IsRequired().HasMaxLength(15);
            builder.Property(x => x.TouristEmail).IsRequired().HasMaxLength(62);
            builder.Property(x => x.State).IsRequired().HasMaxLength(10);

            // relationship config

            // 1-n: tour - orders
            builder.HasOne(order => order.Tour)
                    .WithMany(tour => tour.Orders)
                    .HasForeignKey(order => order.TourId)
                    .OnDelete(DeleteBehavior.NoAction);
                    
            // 1-n: provider - orders
            builder.HasOne(order => order.Provider)
                    .WithMany(provider => provider.Orders)
                    .HasForeignKey(order => order.ProviderId)
                    .OnDelete(DeleteBehavior.NoAction);

            // 1-n: user - orders
            builder.HasOne(order => order.User)
                    .WithMany(user => user.Orders)
                    .HasForeignKey(order => order.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
