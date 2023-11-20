using IT.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT.Persistence.Configurations {
    public class CategoryConfiguration : IEntityTypeConfiguration<Category> {
        public void Configure(EntityTypeBuilder<Category> builder) {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Code).IsRequired().HasMaxLength(8);
            builder.HasOne(p => p.ParentCategory).WithMany(p => p.SubCategories).HasForeignKey(p=> p.ParentCategoryId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}