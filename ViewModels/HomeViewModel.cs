using ShopCar.Interfaces;
using ShopCar.Models;

namespace ShopCar.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car>? favCars { get; set; }
    }
}