namespace BikeShop.Models.Domain.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public ProductRepository()
        {
            // Add 50 random bikes to the products list
            for (int i = 1; i <= 50; i++)
            {
                string[] bikeBrands = { "Trek", "Specialized", "Giant", "Cannondale", "Scott", "Bianchi", "Cervelo", "Pinarello" };
                string bikeName = $"{bikeBrands[new Random().Next(bikeBrands.Length)]}";
                int bikePrice = new Random().Next(500, 5000);
                _products.Add(new Product
                {
                    Name = bikeName,
                    Price = bikePrice
                });
            }
        }

        public List<Product> GetProducts()
        {
            return _products;
        }
    }
}
