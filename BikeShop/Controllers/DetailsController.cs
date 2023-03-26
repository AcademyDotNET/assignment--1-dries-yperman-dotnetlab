using AutoMapper;
using BikeShop.Data.Entities;
using BikeShop.Data.Repositories;
using BikeShop.Data.Repositories.Generic;
using BikeShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ShoppingItem> _shoppingItemRepository;
        private readonly IShoppingBagRepository _shoppingBagRepository;
        private DetailsViewModel _detailsViewModel;

        private int _customerId = 1; // For now there is only one user
        private int _shoppingBagId = 1; // For now there is only one shopping bag

        public DetailsController(IMapper mapper,
            IGenericRepository<Product> productRepository,
            IGenericRepository<ShoppingItem> shoppingItemRepository,
            IShoppingBagRepository shoppingBagRepository)
        {
            _mapper = mapper;

            _productRepository = productRepository;
            _shoppingItemRepository = shoppingItemRepository;
            _shoppingBagRepository = shoppingBagRepository;
            _detailsViewModel = new DetailsViewModel();
        }
        public async Task<IActionResult> Index(int productId)
        {
            var product = await _productRepository.GetById(productId);
            var productDTO = _mapper.Map<ProductDTO>(product);

            _detailsViewModel.Product = productDTO;
            return View(_detailsViewModel);
        }

        public async Task<IActionResult> Submit(int quantity, int productId)
        {
            var shoppingItemDTO = new ShoppingItemDTO { Quantity = quantity, ProductId = productId, ShoppingBagId = _shoppingBagId };
            var shoppingItemEntity = _mapper.Map<ShoppingItem>(shoppingItemDTO);

            await _shoppingItemRepository.Create(shoppingItemEntity);
            await _shoppingBagRepository.AddItem(_shoppingBagId, shoppingItemEntity.Id);

            return RedirectToAction("Index", "Home");
        }
    }
}
