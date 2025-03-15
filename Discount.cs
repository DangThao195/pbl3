using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entities_object
{
    public class Discount
    {
        [Key]
        public Guid DiscountID { get; set; }  

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }  

        [StringLength(500)]
        public string? Describe { get; set; }  

        [Required]
        [Range(0, 100)]  
        public decimal? DiscountRate { get; set; }  

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
