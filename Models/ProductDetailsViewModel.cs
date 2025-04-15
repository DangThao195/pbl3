using PBL3_HK4.Entity;

namespace PBL3_HK4.Models
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; } 
        public IEnumerable<Product> ListProduct { get; set; }
    }
}
