using BikeShop.Models;
using BikeShop.Models.Domain;
using BikeShop.Models.Domain.Customers;
using BikeShop.Models.Domain.ShoppingBags;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers
{
    public class ShoppingBagController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        BikeShopContext _context;

        private Customer _customer;


        public ShoppingBagController(ILogger<HomeController> logger, BikeShopContext context)
        {
            _logger = logger;
            _context = context;
            _customer = _context.customers.First();
        }
        public IActionResult Index()
        {
            var vm = new ShoppingViewModel();
            vm.ShoppingBag = getShoppingBag(_customer);
            return View(vm);
        }

        private ShoppingBag getShoppingBag(Customer customer)
        {
            return _context.shoppingBags.Where(e => e.Customer.Equals(_customer)).First();
        }
    }
}
