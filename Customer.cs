using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entities_object
{
    public class Customer: User
    {
        [Required]
        [StringLength(200)]
        public string? Address { get; set; }

        [Required]
        public int? EarnedPoint { get; set; }
        [ForeignKey("ShoppingCart")]
        public Guid CartID { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
      
    }
}
