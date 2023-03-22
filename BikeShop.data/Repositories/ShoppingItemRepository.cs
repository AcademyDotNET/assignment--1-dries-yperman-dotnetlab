using BikeShop.Data.Entities;
using BikeShop.Data.Repositories.Generic;

namespace BikeShop.Data.Repositories
{
    public class ShoppingItemRepository : GenericRepository<ShoppingItem>, IShoppingItemRepository
    {
        public ShoppingItemRepository(BikeShopContext context) : base(context)
        {
        }
    }
}
