using BikeShop.Models;
using Microsoft.AspNetCore.Mvc;
using BikeShop.Data.Entities;
using BikeShop.Data.Repositories.Generic;
using AutoMapper;
using BikeShop.Services;
using Microsoft.AspNetCore.Authorization;

namespace BikeShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _productRepository;

        private ProductsViewModel _productsViewModel;

        private int _pageSize = 8;

        public ProductsController(IMapper mapper, IGenericRepository<Product> productRepository)
        {
            _mapper = mapper;

            _productRepository = productRepository;

            _productsViewModel = new ProductsViewModel();
        }

        [Authorize]
        public IActionResult Index(int? pageIndex)
        {
            IQueryable<Product> products = _productRepository.GetAll();
            List<ProductDTO> productsDTO = _mapper.Map<List<ProductDTO>>(products);

            var paginatedList = PaginatedList<ProductDTO>.Create(productsDTO, pageIndex ?? 1, _pageSize);
            _productsViewModel.Products = paginatedList;

            return View(_productsViewModel);
        }

        public IActionResult Buy(int quantity, int productId)
        {
            Console.WriteLine(productId.ToString());
            return RedirectToAction("Index", "Details", new { quantity, productId } );
        }
    }
}
