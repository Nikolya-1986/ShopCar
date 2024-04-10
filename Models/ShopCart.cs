using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShopCar.Models
{
    public class ShopCart
    {
        private readonly AppDBContent appDBContent;
        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; } 
        public static ShopCart GetCart(IServiceProvider services)
        { // сессия для работы с товарами в корзине
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>(); // подключение сервиса
            string shopCartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString(); // значение CartId из сессиия
            session?.SetString("CartId", shopCartId);
            #pragma warning disable CS8604 // Possible null reference argument.
            return new ShopCart(context)
            {
                ShopCartId = shopCartId,
            };
            #pragma warning restore CS8604 // Possible null reference argument.
        }

        public void AddToCart(Car car)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                car = car,
                price = car.price,
            });
            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> getShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
        }
    }
}