using AutoMapper;
using BikeShop.Data.Repositories;
using BikeShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers
{
    public class ShoppingBagController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IShoppingBagRepository _shoppingBagRepository;

        private ShoppingBagViewModel _shoppingBagViewModel;

        private int _customerId = 1; // For now there is only one user
        private int _shoppingBagId = 1; // For now there is only one shopping bag

        public ShoppingBagController(IMapper mapper, IShoppingBagRepository shoppingBagRepository)
        {
            _mapper = mapper;

            _shoppingBagRepository = shoppingBagRepository;
            
            _shoppingBagViewModel = new ShoppingBagViewModel();
        }
        public async Task<IActionResult> Index()
        {
            var shoppingBagEntity = await _shoppingBagRepository.GetById(_shoppingBagId);
            var shoppingBagDTO = _mapper.Map<ShoppingBagDTO>(shoppingBagEntity);

            _shoppingBagViewModel.ShoppingBag = shoppingBagDTO;

            return View(_shoppingBagViewModel);
        }
    }
}
