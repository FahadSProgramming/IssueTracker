using System.ComponentModel.DataAnnotations.Schema;

namespace IT.Domain {
    [Table("Applications")]
    public class Application : Entity {
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid OwnerId { get; set; }
        public Contact Owner { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Incident> Incidents { get; set; }
    }
}