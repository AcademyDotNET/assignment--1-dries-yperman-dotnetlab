using BikeShop.Models.Domain.Customers;
using BikeShop.Models.Domain.ShoppingItems;

namespace BikeShop.Models.Domain.ShoppingBags
{
    public class ShoppingBag
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }


        public Customer Customer { get; set; } // Navigation property

        public ICollection<ShoppingItem> Items { get; set; } // Collection navigation property
    }
}
