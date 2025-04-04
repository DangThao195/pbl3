using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_HK4.Entity
{
    public class Discount
    {
        [Key]
        public string? DiscountID { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Describe { get; set; }

        [Required]
        [Range(0, 100)]
        public double? DiscountRate { get; set; }

        [Required]
        public string? ApplicableProduct { get; set; }

        [StringLength(500)]
        public string? Requirement { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
