using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT.Persistence.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Domain.Application> {
        public void Configure(EntityTypeBuilder<Domain.Application> builder) {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Code).IsRequired().HasMaxLength(10);
            builder.HasOne(p => p.Customer).WithMany(p => p.Applications).HasForeignKey(p => p.CustomerId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasOne(p => p.Owner).WithMany(p => p.Applications).HasForeignKey(p => p.OwnerId).OnDelete(DeleteBehavior.Restrict).IsRequired();
        }
    }
}