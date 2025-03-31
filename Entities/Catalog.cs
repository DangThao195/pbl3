using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
