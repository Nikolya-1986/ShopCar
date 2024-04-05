using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopCar.Models;

namespace ShopCar.ViewModels
{
    public class CarsListViewModel // общая модель на основе которой создаются объекты и передаются в шаблоны
    {
        public IEnumerable<Car>? allCars { get; set; }
        public string? currCategory { get; set; }
    }
}