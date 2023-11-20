namespace IT.Domain {
    public class Incident : Entity {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReportedOn { get; set; }
        public DateTime TargetResolutionDate { get; set; }
        public DateTime? ResolvedOn { get; set; }
        public int Status { get; set; }
        public int SeverityLevel { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Contact ReportedBy { get; set; }
        public Guid ReportedById { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}