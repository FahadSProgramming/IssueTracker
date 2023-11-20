using IT.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT.Persistence.Configurations {
    public class ProjectConfiguration : IEntityTypeConfiguration<Project> {
           public void Configure(EntityTypeBuilder<Project> builder) {
                builder.Property(p => p.Name).HasMaxLength(250).IsRequired();
                builder.Property(p => p.Code).HasMaxLength(10).IsRequired();
                builder.Property(p => p.StartedOn).IsRequired().HasDefaultValue(DateTime.UtcNow);
                builder.HasOne(p => p.Owner).WithMany(p => p.Projects).HasForeignKey(p => p.OwnerId).IsRequired().OnDelete(DeleteBehavior.Restrict);
                builder.HasOne(p => p.Application).WithMany(p => p.Projects).HasForeignKey(p => p.ApplicationId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}