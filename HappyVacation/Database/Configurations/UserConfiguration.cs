using HappyVacation.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Username).IsRequired().HasMaxLength(30);
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.PasswordSalt).IsRequired();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(62);

            builder.Property(x => x.ProviderId).IsRequired(false);
            builder.Property(x => x.HotelId).IsRequired(false);


            // relationship config

            // 1-1: user - provider registration
            builder.HasOne(user => user.ProviderRegistration)
                .WithOne(registration => registration.User)
                .HasForeignKey<ProviderRegistration>(registration => registration.UserId);

            // 1-1: user - provider
            builder.HasOne(user => user.Provider)
                .WithOne(provider => provider.User)
                .HasForeignKey<User>(user => user.ProviderId);

            // 1-1: user - hotel
            builder.HasOne(user => user.Hotel)
                .WithOne(hotel => hotel.User)
                .HasForeignKey<User>(user => user.HotelId);
        }
    }
}
