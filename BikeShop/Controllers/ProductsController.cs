using Microsoft.EntityFrameworkCore;
using BikeShop.Models;
using BikeShop.Models.Domain;
using BikeShop.Models.Domain.Products;
using BikeShop.Models.Domain.ShoppingItems;
using BikeShop.Models.Domain.ShoppingBags;
using Microsoft.AspNetCore.Mvc;
using BikeShop.Models.Domain.Customers;

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
            var vm = new DetailsViewModel();
            var product = Read(id);
            if (product != null)
            {
                vm.Product = product;
                return View(vm);
            }
            else return RedirectToAction("Index");
        }
        /*public IActionResult Submit(Product product, int quantity)
        {
            var shoppingItem = new ShoppingItem
            {
                Quantity = quantity,
                Product = product
            };


        }*/

        // -----CRUD-----
        public void Create(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }
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
    }
}
