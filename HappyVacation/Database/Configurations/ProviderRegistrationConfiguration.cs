using HappyVacation.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations
{
    public class ProviderRegistrationConfiguration : IEntityTypeConfiguration<ProviderRegistration>
    {
        public void Configure(EntityTypeBuilder<ProviderRegistration> builder)
        {
            builder.ToTable("ProviderRegistrations");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();           
        }
    }
}
