using BikeShop.Models.Domain;
using BikeShop.Models.Domain.Products;

namespace BikeShop.Models
{
    public class ProductsViewModel
    {
        public PaginatedList<Product> Products { get; set; }
    }
}
