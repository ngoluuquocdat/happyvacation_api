using HappyVacation.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations
{
    public class OrderMemberConfiguration : IEntityTypeConfiguration<OrderMember>
    {
        public void Configure(EntityTypeBuilder<OrderMember> builder)
        {
            builder.ToTable("OrderMembers");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.IdentityNum).IsRequired().HasMaxLength(15);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(60);
            builder.Property(x => x.DateOfBirth).IsRequired();


            // relationship config
            // 1-n: order - order members
            builder.HasOne(orderMember => orderMember.Order)
                    .WithMany(order => order.OrderMembers)
                    .HasForeignKey(orderMember => orderMember.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
