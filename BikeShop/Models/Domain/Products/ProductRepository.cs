namespace BikeShop.Models.Domain.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>()
        {
            new Product
            {
                Name = "Eddy Merckx", Price = 2099
            },
            new Product
            {
                Name = "Trek", Price = 899
            },
            new Product
            {
                Name = "Rocky Mountain", Price = 1099
            }
        };
        public List<Product> GetProducts()
        {
            return _products;
        }
    }
}
