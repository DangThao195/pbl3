using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PBL3_HK4.Entity
{
    public class User
    {
        [Key]
        [Required]
        public Guid UserID { get; set; }

        [StringLength(40)]
        public string? Name { get; set; }

        [StringLength(40)]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(10)]
        public string? Sex { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(20)]
        public string? Phone {  get; set; }

        [StringLength(40)]
        [Required]
        public string UserName { get; set; }

        [StringLength(200)]
        [Required]
        public string PassWord { get; set; }

        [StringLength(50)]
        public string? Role { get; set; }
    }
}
