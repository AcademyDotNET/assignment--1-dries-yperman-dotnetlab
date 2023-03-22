using BikeShop.Data.Entities;
using BikeShop.Data.Repositories.Generic;

namespace BikeShop.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(BikeShopContext context) : base(context)
        {
        }
    }
}
