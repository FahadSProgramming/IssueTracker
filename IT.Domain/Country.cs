namespace IT.Domain {
    public class Country : Entity {
        public string Name { get; set; }
        public string ISOCode { get; set; }
        public string ISOCode3 { get; set; }
        public string PhoneCode { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}