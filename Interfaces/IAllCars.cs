using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopCar.Models;

namespace ShopCar.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> getFavCars { get; }
        Car getObjCar (int carId);
    }
}