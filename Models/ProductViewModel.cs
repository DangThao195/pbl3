using PBL3_HK4.Entity;

namespace PBL3_HK4.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Catalog> Catalogs { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}