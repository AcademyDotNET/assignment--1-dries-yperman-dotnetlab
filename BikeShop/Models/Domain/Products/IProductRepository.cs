namespace BikeShop.Models.Domain.Products
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
    }
}
