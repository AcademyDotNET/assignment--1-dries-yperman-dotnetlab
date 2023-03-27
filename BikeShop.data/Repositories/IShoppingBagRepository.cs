using BikeShop.Data.Entities;
using BikeShop.Data.Repositories.Generic;

namespace BikeShop.Data.Repositories
{
    public interface IShoppingBagRepository : IGenericRepository<ShoppingBag>
    {
        public Task AddItem(int shoppingBagId, int shoppingItemId);
    }
}
