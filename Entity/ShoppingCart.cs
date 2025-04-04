using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_HK4.Entity
{
    public class ShoppingCart
    {
        [Key]
        public string? CartID { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public string? CustomerID { get; set; }
        public virtual Customer? Customer { get; set; }

        public virtual ICollection<CartItem> Items { get; set; } = new List<CartItem>();

        [NotMapped]
        public double TotalAmount
        {
            get
            {
                return Items.Sum(i => i.TotalPrice);
            }
        }
    }
}
