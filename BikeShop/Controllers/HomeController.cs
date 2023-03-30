using BikeShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BikeShop.Controllers
{
    public class HomeController : Controller
    {
        private HomeViewModel _viewModel;
        private Login _login;

        public HomeController()
        {
            _viewModel = new HomeViewModel();
            _login = new Login();
        }

        public IActionResult Index()
        {
            return View(_viewModel);
        }

        public IActionResult Login()
        {
            return View(_login);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}