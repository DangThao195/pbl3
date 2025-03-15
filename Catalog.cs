using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entities_object
{
    public class Catalog
    {
        [Key]
        [Required]
        public Guid CatalogID { get; set; }
        [Required]
        [StringLength(40)]
        public string? CatalogName { get; set; }


    }
}
