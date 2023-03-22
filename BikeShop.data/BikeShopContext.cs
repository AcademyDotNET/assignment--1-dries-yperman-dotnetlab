using BikeShop.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Data
{
    public class BikeShopContext : DbContext
    {
        public BikeShopContext(DbContextOptions<BikeShopContext> options) : base(options) { }

        public DbSet<Product> products { get; set; }
        public DbSet<ShoppingItem> shoppingItems { get; set; }
        public DbSet<ShoppingBag> shoppingBags { get; set; }
        public DbSet<Customer> customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var products = GenerateBikes();
            var customer = new Customer { Id = 1, Name = "Yperman", FirstName = "Dries" };
            var shoppingBag = new ShoppingBag { Id = 1, Date = DateTime.Now, CustomerId = customer.Id };

            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<Customer>().HasData(customer);
            modelBuilder.Entity<ShoppingBag>().HasData(shoppingBag);

            base.OnModelCreating(modelBuilder);
        }

        private List<Product> GenerateBikes()
        {
            var products = new List<Product>();
            for (int i = 1; i <= 50; i++)
            {
                string[] bikeBrands = { "Trek", "Specialized", "Giant", "Cannondale", "Scott", "Bianchi", "Cervelo", "Pinarello" };
                string bikeName = $"{bikeBrands[new Random().Next(bikeBrands.Length)]}";
                int bikePrice = new Random().Next(500, 5000);
                products.Add(new Product
                { 
                    Id = i,
                    Name = bikeName,
                    Price = bikePrice
                });
            }

            return products;
        }
    }
}