using IT.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT.Persistence.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact> {
        public void Configure(EntityTypeBuilder<Contact> builder) {
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(250);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Designation).HasMaxLength(100);
            builder.Property(p => p.MiddleName).HasMaxLength(250);
            builder.Property(p => p.PrimaryPhone).HasMaxLength(20);
            builder.Property(p => p.SecondaryPhone).HasMaxLength(20);
            builder.Property(p => p.EmailAddress).HasMaxLength(150);
            builder.Property(p => p.SecondaryEmailAddress).HasMaxLength(150);
            builder.HasOne(p => p.Customer).WithMany(p => p.Contacts).HasForeignKey(p => p.CustomerId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasOne(p => p.SystemUser).WithOne(p => p.Contact).OnDelete(DeleteBehavior.SetNull);
        }
    }
}