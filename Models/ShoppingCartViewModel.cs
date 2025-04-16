using PBL3_HK4.Entity;

namespace PBL3_HK4.Models
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public IEnumerable<Product> Products { get; set; }

        public Product GetProductByCartId(Guid productId)
        {
            var product = Products.FirstOrDefault(p => p.ProductID == productId);
            return product;
        }

    }
}
