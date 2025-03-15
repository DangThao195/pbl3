using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entities_object
{
    public class ShoppingCart
    {
        [Key]
        public Guid CartID { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public Guid CustomerID { get; set; }
        public virtual Customer? Customer { get; set; }

        public virtual ICollection<CartItem> Items { get; set; } = new List<CartItem>();

        [NotMapped]
        public decimal TotalAmount
        {
            get
            {
                return Items.Sum(i => i.TotalPrice);
            }
        }

    }
}
