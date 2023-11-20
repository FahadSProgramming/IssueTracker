using IT.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT.Persistence.Configurations {
    public class IncidentConfiguration : IEntityTypeConfiguration <Incident> {
        public void Configure(EntityTypeBuilder<Incident> builder) {
            builder.Property(p => p.Title).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Status).IsRequired().HasDefaultValue(1000);
            builder.Property(p => p.Status).IsRequired().HasDefaultValue(1000);
            builder.Property(p => p.ReportedOn).IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.HasOne(p => p.Category).WithMany(p => p.Incidents).HasForeignKey(p => p.CategoryId).IsRequired();
            builder.HasOne(p => p.ReportedBy).WithMany(p => p.ReportedIncidents).HasForeignKey(p => p.ReportedById);
            builder.HasOne(p => p.Customer).WithMany(p => p.ReportedIncidents).HasForeignKey(p => p.CustomerId).IsRequired();
            builder.HasOne(p => p.Application).WithMany(p => p.Incidents).HasForeignKey(p => p.ApplicationId).IsRequired();
            builder.HasOne(p => p.Project).WithMany(p => p.Incidents).HasForeignKey(p => p.ProjectId).IsRequired();
        }
    }
}