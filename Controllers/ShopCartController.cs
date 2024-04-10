using Microsoft.AspNetCore.Mvc;
using ShopCar.Interfaces;
using ShopCar.Models;
using ShopCar.ViewModels;

namespace ShopCar.Controllers
{
    public class ShopCartController: Controller
    {
        private readonly IAllCars _carRepository;
        private readonly ShopCart _shopCart;
        public ShopCartController(IAllCars carRepository, ShopCart shopCart)
        {
            _carRepository = carRepository;
            _shopCart = shopCart;
        }
        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;
            ShopCartViewModel obj = new ShopCartViewModel
            {
                shopCart = _shopCart,
            };
            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRepository.Cars.FirstOrDefault(i => i.id == id);
            if(item != null)
            {
                _shopCart.AddToCart(item);
            };
            return RedirectToAction("Index"); // при добавлении товара произойдёт редирект на страницу корзины
        }
    }
}