using IT.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IT.Persistence {
    public class DataContext : IdentityDbContext<SystemUser>
    {
        public DataContext(DbContextOptions options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken) {
            EntityAuditing(ChangeTracker);
            return base.SaveChangesAsync(cancellationToken);
        }
        private void EntityAuditing(Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker changeTracker) {
            // Add creation stamp
            changeTracker.Entries()
                         .Where(x => x.State == EntityState.Added)
                         .ToList()
                         .ForEach(entity => {
                             entity.Property("CreatedOn").CurrentValue = DateTime.UtcNow;
                             entity.Property("ModifiedOn").CurrentValue = DateTime.UtcNow;
                         });
            changeTracker.Entries()
                         .Where(x => x.State == EntityState.Modified)
                         .ToList()
                         .ForEach(entity => {
                             entity.Property("ModifiedOn").CurrentValue = DateTime.UtcNow;
                         });
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }
    }
}