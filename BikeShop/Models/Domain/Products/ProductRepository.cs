namespace BikeShop.Models.Domain.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>()
        {
            new Product
            {
                Id = 1, Name = "Eddy Merckx", Price = 2099
            },
            new Product
            {
                Id = 2, Name = "Trek", Price = 899
            },
            new Product
            {
                Id = 3, Name = "Rocky Mountain", Price = 1099
            }
        };
        public List<Product> GetProducts()
        {
            return _products;
        }
    }
}
