using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities
{
    public class Customer : User
    {
        [Required]
        [StringLength(200)]
        public string? Address { get; set; }

        [Required]
        public int? EarnedPoint { get; set; }
        [ForeignKey("ShoppingCart")]
        public string? CartID { get; set; }
        public virtual ShoppingCart? ShoppingCart { get; set; }
        public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
    }
}
