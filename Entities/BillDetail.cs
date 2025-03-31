using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities
{
    public class BillDetail
    {
        [Key]
        public string? BillDetailID { get; set; }

        [ForeignKey("Product")]
        public string? ProductID { get; set; }
        public virtual Product? Product { get; set; }

        [ForeignKey("Bill")]
        public string? BillID { get; set; }
        public virtual Bill? Bill { get; set; }

        [ForeignKey("Discount")]
        public string? DiscountID { get; set; }
        public virtual Discount? Discount { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public double Total
        {
            get
            {
                if (Quantity.HasValue && Price.HasValue)
                {
                    double discountRate = Discount?.DiscountRate ?? 1;
                    return Quantity.Value * Price.Value * discountRate;
                }
                return 0;

            }
        }
    }
}
