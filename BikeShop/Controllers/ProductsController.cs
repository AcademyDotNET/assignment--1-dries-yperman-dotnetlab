﻿using BikeShop.Models;
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

        public ProductsController(ILogger<HomeController> logger, BikeShopContext context)
        {
            _logger = logger;
            //_productRepository = productRepository;
            _context = context;
        }
        public IActionResult Index()
        {
            _logger.LogDebug("Showing a list with all the products to the user.");

            var vm = new ProductsViewModel();
            //var products = _productRepository.GetProducts();
            var products = _context.products.ToList();
            vm.Products = products;
            return View(vm);
        }
    }
}
