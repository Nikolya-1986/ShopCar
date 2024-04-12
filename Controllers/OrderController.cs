using Microsoft.AspNetCore.Mvc;
using ShopCar.Interfaces;
using ShopCar.Models;

namespace ShopCar.Controllers
{
    public class OrderController: Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;
        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout() // вызывается при переходе на страницу
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order) // вызывается после завершения заказа
        {
            shopCart.listShopItems = shopCart.getShopItems();
            if (shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары"); // вывод сообщения, ключ и значение
            }
            if (ModelState.IsValid)
            {
                allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}