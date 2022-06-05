using HappyVacation.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations
{
    public class WishItemConfiguration : IEntityTypeConfiguration<WishItem>
    {
        public void Configure(EntityTypeBuilder<WishItem> builder)
        {
            builder.ToTable("WishItems");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            // relationship config
            // 1-n: user - wish items
            builder.HasOne(wishItem => wishItem.User)
                .WithMany(user => user.WishItems)
                .HasForeignKey(wishItem => wishItem.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // 1-n: tour - wish items
            builder.HasOne(wishItem => wishItem.Tour)
                .WithMany(tour => tour.WishItems)
                .HasForeignKey(wishItem => wishItem.TourId);
        }
    }
}
