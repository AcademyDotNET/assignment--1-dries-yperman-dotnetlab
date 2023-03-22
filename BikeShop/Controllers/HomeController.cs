using BikeShop.Models;
using BikeShop.Models.Domain;
using BikeShop.Models.Domain.Customers;
using BikeShop.Models.Domain.Products;
using BikeShop.Models.Domain.ShoppingBags;
using BikeShop.Models.Domain.ShoppingItems;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BikeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        BikeShopContext _context;

        private static int count = 0;

        public HomeController(ILogger<HomeController> logger, BikeShopContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var vm = new IndexViewModel();
            count = (count % 4) + 1;
            _logger.LogInformation(count.ToString());
            vm.Count = count;
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}