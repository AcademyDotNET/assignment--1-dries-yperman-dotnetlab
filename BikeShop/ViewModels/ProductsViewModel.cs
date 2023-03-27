using BikeShop.Services;

namespace BikeShop.Models
{
    public class ProductsViewModel
    {
        public PaginatedList<ProductDTO>? Products { get; set; }
    }
}
