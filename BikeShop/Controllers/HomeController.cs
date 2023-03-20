using BikeShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BikeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static int count = 0;

        public HomeController(ILogger<HomeController> logger)
        { 
            _logger = logger;
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