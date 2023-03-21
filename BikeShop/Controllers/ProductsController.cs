using Microsoft.EntityFrameworkCore;
using BikeShop.Models;
using BikeShop.Models.Domain;
using BikeShop.Models.Domain.Products;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IProductRepository _productRepository;
        BikeShopContext _context;

        private int pageSize = 8;

        public ProductsController(ILogger<HomeController> logger, BikeShopContext context)
        {
            _logger = logger;
            //_productRepository = productRepository;
            _context = context;
        }
        public async Task<IActionResult> Index(int? pageNumber)
        {
            _logger.LogDebug("Showing a list with all the products to the user.");

            var vm = new ProductsViewModel();
            IQueryable<Product> products = _context.products.AsQueryable()
                .OrderBy(e => e.Name).ThenBy(e => e.Price);
            var paginatedProducts = await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize);
            vm.Products = paginatedProducts;
            return View(vm);
        }

        public IActionResult AddProducts()
        {
            _logger.LogDebug("Adding a list of products.");

            IProductRepository productRepository = new ProductRepository();
            var products = productRepository.GetProducts();

            foreach (Product product in products)
            {
                _logger.LogDebug($"Adding product: {product.Name}");
                _context.Add(product);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
