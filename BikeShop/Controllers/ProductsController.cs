using BikeShop.Models;
using BikeShop.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductsController(ILogger<HomeController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            _logger.LogDebug("Showing a list with all the products to the user.");

            var vm = new ProductsViewModel();
            var products = _productRepository.GetProducts();
            vm.Products = products;
            return View(vm);
        }
    }
}
