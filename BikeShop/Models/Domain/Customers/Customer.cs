using BikeShop.Models.Domain.ShoppingBags;

namespace BikeShop.Models.Domain.Customers
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int FirstName { get; set; }

        public List<ShoppingBag> Bags { get; set; }
    }
}
