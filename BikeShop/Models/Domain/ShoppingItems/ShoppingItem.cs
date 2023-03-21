using BikeShop.Models.Domain.Products;
using BikeShop.Models.Domain.ShoppingBags;

namespace BikeShop.Models.Domain.ShoppingItems
{
    public class ShoppingItem
    {
        public long Id { get; set; }
        public int Quantity { get; set; }

        public ShoppingBag Bag { get; set; }
        public Product Product { get; set; }
    }
}
