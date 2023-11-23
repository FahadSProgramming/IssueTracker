using System.ComponentModel.DataAnnotations.Schema;

namespace IT.Domain {
    [Table("Customers")]
    public class Customer : Entity {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string WebAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PostalCode { get; set; }
        public int Rating { get; set; }
        public DateTime SigningDate { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<SystemUserRequest> UserRequests { get; set; }
        public ICollection<Application> Applications { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Incident> ReportedIncidents { get; set; }
    }
}