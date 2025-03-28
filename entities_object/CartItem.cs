using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entities_object
{
    public class CartItem
    {
        [Key]
        public string ItemID { get; set; }

        [Required]
        [ForeignKey("Product")]
        public string ProductID { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        [ForeignKey("ShoppingCart")]
        public string CartID { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; } = 1;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public double Price { get; set; }

        [NotMapped] 
        public double TotalPrice
        {
            get
            {
                return this.Quantity * this.Price;
            }
            set { }
        }

    }
}
