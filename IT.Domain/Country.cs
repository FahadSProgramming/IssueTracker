using System.ComponentModel.DataAnnotations.Schema;

namespace IT.Domain {
    [Table("Countries")]
    public class Country : Entity {
        public string Name { get; set; }
        public string ISOCode { get; set; }
        public string ISOCode3 { get; set; }
        public string PhoneCode { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}