using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entities_object
{
    public class Bill
    {
        [Key]
        public string BillID { get; set; } 

        [ForeignKey("Customer")]
        public string CustomerID { get; set; } 
        public virtual Customer Customer { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } 

        [Required]
        [StringLength(200)]  
        public string Address { get; set; }

        public virtual ICollection<BillDetail> BillDetails { get; set; } = new List<BillDetail>();

        [Required]
        [Range(0.01, double.MaxValue)]
        public double TotalPrice
        {
            get => BillDetails?.Sum(b => b.Total) ?? 0;
            set { }
        }
    }
}
