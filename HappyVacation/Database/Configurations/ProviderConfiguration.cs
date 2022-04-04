using HappyVacation.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable("Providers");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.ProviderName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ProviderPhone).IsRequired().HasMaxLength(15);
            builder.Property(x => x.ProviderEmail).IsRequired().HasMaxLength(62);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(100);

        }
    }
}
