using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Catalog
    {
        [Key]
        [Required]
        public string? CatalogID { get; set; }
        [Required]
        [StringLength(40)]
        public string? CatalogName { get; set; }
    }
}
