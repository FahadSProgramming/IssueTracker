using IT.Application.Enums;

namespace IT.Application.Customer.Queries {
    public class CustomerDto {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string WebAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PostalCode { get; set; }
        public CustomerRating Rating { get; set; }
        public DateTime SigningDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid CountryId { get; set; }        
    }
}