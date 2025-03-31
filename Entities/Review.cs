using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Review
    {
        [Key]
        public string? ReviewID { get; set; }

        [ForeignKey("Product")]
        public string? ProductID { get; set; }
        public virtual Product? Product { get; set; }

        [ForeignKey("Customer")]
        public string? CustomerID { get; set; }
        public virtual Customer? Customer { get; set; }

        [Range(1, 5)]
        public int? Rating { get; set; }

        [StringLength(100)]
        public string? Text { get; set; }

        [Required]
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}
