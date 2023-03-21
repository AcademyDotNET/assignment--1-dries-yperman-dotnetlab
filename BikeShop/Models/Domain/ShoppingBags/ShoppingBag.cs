using BikeShop.Models.Domain.Customers;
using BikeShop.Models.Domain.ShoppingItems;

namespace BikeShop.Models.Domain.ShoppingBags
{
    public class ShoppingBag
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }

        public Customer Customer { get; set; }
        public List<ShoppingItem> Items { get; set; }
    }
}
