namespace IT.Domain {
    public class SystemUserRequest : Entity {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public Guid RequestorId { get; set; }
        public Contact Requestor { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid? SystemUserId { get; set; }
        public SystemUser SystemUser { get; set; }
    }
}