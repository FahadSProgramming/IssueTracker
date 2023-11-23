using System.ComponentModel.DataAnnotations.Schema;

namespace IT.Domain {
    [Table("Projects")]
    public class Project : Entity {
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public Guid OwnerId { get; set; }
        public Contact Owner { get; set; }
        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }
        public ICollection<Incident> Incidents { get; set; }
    }
}