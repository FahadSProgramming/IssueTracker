using System.ComponentModel.DataAnnotations.Schema;

namespace IT.Domain {
    [Table("Categories")]
    public class Category : Entity {
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; }
        public ICollection<Incident> Incidents { get; set; }
    }
}