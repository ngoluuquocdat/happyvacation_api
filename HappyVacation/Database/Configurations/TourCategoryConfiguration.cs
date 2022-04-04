using HappyVacation.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HappyVacation.Database.Configurations
{
    public class TourCategoryConfiguration : IEntityTypeConfiguration<TourCategory>
    {
        public void Configure(EntityTypeBuilder<TourCategory> builder)
        {
            builder.ToTable("TourCategories");

            // composite key
            builder.HasKey(x => new {x.TourId, x.CategoryId});

            // relationship config

            // 1-n: tour - tour categories
            builder.HasOne(tourCategory => tourCategory.Tour)
                .WithMany(tour => tour.TourCategories)
                .HasForeignKey(tourCategory => tourCategory.TourId);
            // 1-n: category - tour categories
            builder.HasOne(tourCategory => tourCategory.Category)
                .WithMany(category => category.TourCategories)
                .HasForeignKey(tourCategory => tourCategory.CategoryId);
        }
    }
}
