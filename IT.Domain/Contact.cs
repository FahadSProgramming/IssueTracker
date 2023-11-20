namespace IT.Domain {
    public class Contact : Entity {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecondaryPhone  { get; set; }
        public string EmailAddress { get; set; }
        public string SecondaryEmailAddress { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Application> Applications { get; set; }
        public ICollection<Incident> ReportedIncidents { get; set; }
    }
}