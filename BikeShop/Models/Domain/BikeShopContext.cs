using BikeShop.Models.Domain.Customers;
using BikeShop.Models.Domain.Products;
using BikeShop.Models.Domain.ShoppingBags;
using BikeShop.Models.Domain.ShoppingItems;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Models.Domain
{
    public class BikeShopContext : DbContext
    {
        public BikeShopContext(DbContextOptions<BikeShopContext> options) : base(options) { }

        public DbSet<Product> products { get; set; }
        public DbSet<ShoppingItem> shoppingItems { get; set; }
        public DbSet<ShoppingBag> shoppingBags { get; set; }
        public DbSet<Customer> customers { get; set; }
    }
}
