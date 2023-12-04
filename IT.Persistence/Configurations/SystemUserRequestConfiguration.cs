namespace IT.Persistence.Configurations {
    // public class SystemUserRequestConfiguration : IEntityTypeConfiguration<Domain.SystemUserRequest> {
    //     public void Configure(EntityTypeBuilder<Domain.SystemUserRequest> builder) {
    //         builder.Property(p => p.DisplayName).IsRequired().HasMaxLength(300);
    //         builder.Property(p => p.Email).IsRequired().HasMaxLength(250);
    //         builder.Property(p => p.Description).HasMaxLength(500);
    //         builder.Property(p => p.Position).HasMaxLength(100);
    //         builder.HasOne(p => p.Requestor).WithMany(p => p.UserRequests).HasForeignKey(p => p.RequestorId).IsRequired().OnDelete(DeleteBehavior.Restrict);
    //         builder.HasOne(p => p.Customer).WithMany(p => p.UserRequests).HasForeignKey(p => p.CustomerId).IsRequired().OnDelete(DeleteBehavior.Restrict);
    //         builder.HasOne(p => p.SystemUser).WithOne(p => p.UserRequest).OnDelete(DeleteBehavior.Restrict);
    //         builder.HasOne(p => p.AssignedTo).WithMany(p => p.SystemUserRequests).HasForeignKey(p => p.AssignedToId).OnDelete(DeleteBehavior.Restrict);

    //     }
    // }
}