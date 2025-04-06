using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace PBL3_HK4.Entity
{
    public class Product
    {
        [Key]
        [Required]
        public Guid ProductID { get; set; }

        [Required]
        public Guid CatalogID { get; set; }
        public Catalog Catalog { get; set; }


        [Required]
        [StringLength(100)]
        public string? ProductName { get; set; }

        [StringLength(500)]
        public string? ProductDescription { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime MFGDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EXPDate { get; set; }

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        [NotMapped]
        public float AverageRating
        {
            get => Reviews.Any() ? (float)Reviews.Average(i => i.Rating) : 0;
        }
    }
}
