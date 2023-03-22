using BikeShop.Models;
using Microsoft.AspNetCore.Mvc;
using BikeShop.Data.Repositories;
using BikeShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using AspNetCore;

// Now using entities --> ModelMapper?

namespace BikeShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IShoppingBagRepository _shoppingBagRepository;

        private ProductsViewModel _productsViewModel;
        private DetailsViewModel _detailsViewModel;

        private int customerId = 1; // For now there is only one user
        private int _pageSize = 8;

        public ProductsController(IProductRepository productRepository, IShoppingBagRepository shoppingBagRepository)
        {
            _productRepository = productRepository;
            _shoppingBagRepository = shoppingBagRepository;

            _productsViewModel = new ProductsViewModel();
            _detailsViewModel = new DetailsViewModel();
        }

        public async Task<IActionResult> Index(int? pageIndex)
        {
            var products = _productRepository.GetAll();
            var paginatedList = await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageIndex ?? 1, _pageSize);
            _productsViewModel.Products = paginatedList;
            return View(_productsViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetById(id);
            _detailsViewModel.Product = product;
            return View(_detailsViewModel);
        }

        public async Task<IActionResult> Submit(int productId, int quantity)
        {

            return RedirectToAction("Index", "ShoppingBagController");
        }

        /*
        public IActionResult Submit(int productId, int quantity)
        {
            var product = _context.products.First(e => e.Id == productId);
            var shoppingItem = new ShoppingItem { Quantity = quantity, Product = product };
            _context.shoppingItems.Add(shoppingItem);
            _context.SaveChanges();

            var shoppingBag = _context.shoppingBags.First(e => e.Customer == _customer);

            _logger.LogInformation(shoppingBag.Items.First().Id.ToString());

            return RedirectToAction("Index", "ShoppingBagController");
        }

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
        // -----CRUD-----*/
    }
}
