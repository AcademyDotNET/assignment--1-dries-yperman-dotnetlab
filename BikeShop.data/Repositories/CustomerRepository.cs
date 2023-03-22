using BikeShop.Data.Entities;
using BikeShop.Data.Repositories.Generic;

namespace BikeShop.Data.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BikeShopContext context) : base(context)
        {
        }
    }
}
