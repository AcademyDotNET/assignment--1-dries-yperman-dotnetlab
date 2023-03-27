using BikeShop.Data.Entities;
using BikeShop.Data.Repositories.Generic;
using Microsoft.EntityFrameworkCore;

namespace BikeShop.Data.Repositories
{
    public class ShoppingBagRepository : GenericRepository<ShoppingBag>, IShoppingBagRepository
    {
        BikeShopContext _context;

        GenericRepository<ShoppingItem> _shoppingItemRepository;
        public ShoppingBagRepository(BikeShopContext context) : base(context)
        {
            _context = context;
            _shoppingItemRepository = new GenericRepository<ShoppingItem>(context);
        }

        public override async Task<ShoppingBag?> GetById(int id)
        {
            return await _context.Set<ShoppingBag>()
                .Include(x => x.Items)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddItem(int shoppingBagId, int shoppingItemId)
        {
            var shoppingItem = await _shoppingItemRepository.GetById(shoppingItemId);
            if (shoppingItem != null)
            {
                var shoppingBag = await this.GetById(shoppingBagId);
                if (shoppingBag != null)
                {
                    shoppingItem.ShoppingBagId = shoppingBagId;

                    //shoppingBag.Items.Add(shoppingItem);
                    //_context.Set<ShoppingBag>().Attach(shoppingBag);

                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
