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
        public string? UserID { get; set; }

        [Required]
        [StringLength(40)]
        public string? Name { get; set; }

        [Required]
        [StringLength(40)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(10)]
        public string? Sex { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(40)]
        public string? UserName { get; set; }

        [Required]
        [StringLength(40)]
        public string? PassWord { get; set; }

        [Required]
        [StringLength(40)]
        public string? Role { get; set; }
    }
}
