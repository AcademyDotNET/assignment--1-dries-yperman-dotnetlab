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
        public IActionResult Details(int id)
        {
            _logger.LogInformation(id.ToString());
            var vm = new DetailsViewModel();
            var product = Read(id);
            if (product != null)
            {
                vm.Product = product;
                return View(vm);
            } else return RedirectToAction("Index");
        }

        // -----CRUD-----
        public void Create(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();        }
        private Product? Read(int id)
        {
            Product? product = _context.products.Where(e => e.Id == id).FirstOrDefault();
            return product;
        }
        public void Update(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Remove(id);
        }
        // -----CRUD-----

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
