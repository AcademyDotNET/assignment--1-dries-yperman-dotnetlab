using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers
{
    public class DetailsController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public DetailsController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogDebug("Showing the details of the product to the user.");
            return View();
        }
    }
}
