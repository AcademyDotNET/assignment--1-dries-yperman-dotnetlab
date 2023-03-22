using BikeShop.Data.Entities;

namespace BikeShop.Models
{
    public class ProductsViewModel
    {
        public PaginatedList<Product>? Products { get; set; }
    }
}
