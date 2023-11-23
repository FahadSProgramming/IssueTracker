using IT.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT.Persistence.Configurations {
    public class SystemUserConfigurations : IEntityTypeConfiguration<SystemUser> {
        public void Configure(EntityTypeBuilder<SystemUser> builder) {
            builder.Property(p => p.DisplayName).IsRequired().HasMaxLength(300);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.HasOne(p => p.Contact) .WithOne(p => p.SystemUser).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.UserRequest).WithOne(p => p.SystemUser).OnDelete(DeleteBehavior.SetNull);
        }        
    }
}