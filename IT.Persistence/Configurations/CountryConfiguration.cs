using IT.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT.Persistence.Configurations {
    public class CountryConfiguration : IEntityTypeConfiguration<Country> {
        public void Configure(EntityTypeBuilder<Country> builder) {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(250);
            builder.Property(p => p.ISOCode).IsRequired().HasMaxLength(2);
            builder.Property(p => p.ISOCode3).IsRequired().HasMaxLength(3);
            builder.Property(p => p.PhoneCode).HasMaxLength(5);
        }
    }
}