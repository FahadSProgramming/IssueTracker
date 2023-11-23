using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace IT.Domain {
    [Table("SystemUsers")]
    public class SystemUser : IdentityUser {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public Guid? ContactId { get; set; }
        public Contact Contact { get; set; }
        public bool Enabled { get; set; }
        public Guid? SystemUserRequestId { get; set; }
        public SystemUserRequest UserRequest { get; set; }
    }
}