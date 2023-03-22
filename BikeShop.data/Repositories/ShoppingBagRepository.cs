using BikeShop.Data.Entities;
using BikeShop.Data.Repositories.Generic;

namespace BikeShop.Data.Repositories
{
    public class ShoppingBagRepository : GenericRepository<ShoppingBag>, IShoppingBagRepository
    {
        public ShoppingBagRepository(BikeShopContext context) : base(context)
        {
        }
    }
}
