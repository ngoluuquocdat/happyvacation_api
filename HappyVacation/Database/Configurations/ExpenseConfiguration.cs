using HappyVacation.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Expenses");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.IsIncluded).IsRequired();

            // relationship config

            // 1-n: tour - expenses
            builder.HasOne(expense => expense.Tour)
                .WithMany(tour => tour.Expenses)
                .HasForeignKey(expense => expense.TourId);
        }
    }
}
