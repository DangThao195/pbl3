using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace entities_object
{
    public class BillDetail
    {
        [Key]
        public Guid BillDetailID { get; set; }

        [ForeignKey("Product")]
        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Bill")]
        public Guid BillID { get; set; }
        public virtual Bill Bill { get; set; }

        [ForeignKey("Discount")]
        public Guid? DiscountID { get; set; }
        public virtual Discount? Discount { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal Total {
            get
            {
                if (Quantity.HasValue && Price.HasValue)
                {
                    decimal discountRate = Discount?.DiscountRate ?? 1;
                    return Quantity.Value * Price.Value * discountRate;
                }
                return 0;

            }
        }



    }
}
