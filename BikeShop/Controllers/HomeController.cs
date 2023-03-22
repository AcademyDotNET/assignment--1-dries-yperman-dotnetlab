using BikeShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BikeShop.Controllers
{
    public class HomeController : Controller
    {
        private HomeViewModel _viewModel;

        public HomeController()
        {
            _viewModel = new HomeViewModel();
        }

        public IActionResult Index()
        {
            return View(_viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}