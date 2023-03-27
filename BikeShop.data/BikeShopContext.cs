using BikeShop.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Data
{
    public class BikeShopContext : DbContext
    {
        public BikeShopContext(DbContextOptions<BikeShopContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingItem> ShoppingItems { get; set; }
        public DbSet<ShoppingBag> ShoppingBags { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(product => product.Property(e => e.Price).HasColumnType("decimal(8,2)"));

            var products = GenerateBikes(50);
            var customer = new Customer { Id = 1, Name = "Yperman", FirstName = "Dries" };
            var shoppingBag = new ShoppingBag { Id = 1, Date = DateTime.Now, CustomerId = customer.Id };

            modelBuilder.Entity<Product>().HasData(products);
            modelBuilder.Entity<Customer>().HasData(customer);
            modelBuilder.Entity<ShoppingBag>().HasData(shoppingBag);

            base.OnModelCreating(modelBuilder);
        }

        private List<Product> GenerateBikes(int total)
        {
            var products = new List<Product>();
            for (int i = 1; i < total; i++)
            {
                string[] bikeBrands = { "Trek", "Specialized", "Giant", "Cannondale", "Scott", "Bianchi", "Cervelo", "Pinarello" };
                string bikeName = $"{bikeBrands[(i-1) % 8]}";
                int bikePrice = i * 100;
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