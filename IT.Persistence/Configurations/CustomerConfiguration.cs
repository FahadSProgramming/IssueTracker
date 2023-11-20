using IT.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT.Persistence.Configurations {
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer> {
        public void Configure(EntityTypeBuilder<Customer> builder) {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Phone).HasMaxLength(20);
            builder.Property(p => p.WebAddress).HasMaxLength(250);
            builder.Property(p => p.AddressLine1).HasMaxLength(250);
            builder.Property(p => p.AddressLine2).HasMaxLength(250);
            builder.Property(p => p.PostalCode).HasMaxLength(20);
            builder.Property(p => p.SigningDate).HasDefaultValue(DateTime.UtcNow);
            builder.HasOne(p => p.Country).WithMany(p => p.Customers).HasForeignKey(p => p.CountryId).IsRequired().OnDelete(DeleteBehavior.SetNull);
        }
    }
}