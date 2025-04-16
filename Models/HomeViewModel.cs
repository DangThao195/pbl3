using PBL3_HK4.Entity;

namespace PBL3_HK4.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Catalog> Catalogs { get; set; }
    }
}