using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopCar.Interfaces;
using ShopCar.Models;

namespace ShopCar.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;
        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = shopCart.listShopItems;
            foreach(var elem in items)
            {
                var orderDetail = new OrderDetail()
                {
                    carId = elem.car.id,
                    orderId = order.id,
                    price = elem.car.price,
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }
            appDBContent.SaveChanges(); // сохранение в базе данных
        }
    }
}