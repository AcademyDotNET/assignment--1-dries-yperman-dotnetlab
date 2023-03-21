using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers
{
    public class ShoppingBagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
