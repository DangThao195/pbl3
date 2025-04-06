
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace PBL3_HK4.Entity
{
    public class Bill
    {
        [Key]
        public Guid BillID { get; set; }

        [ForeignKey("Customer")]
        public Guid? CustomerID { get; set; }
        public virtual Customer? Customer { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(200)]
        public string? Address { get; set; }

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
