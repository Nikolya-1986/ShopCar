using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopCar.Interfaces;
using ShopCar.ViewModels;

namespace ShopCar.Controllers
{
    public class CarsController: Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCarsCategory;

        public CarsController(IAllCars iAllCars, ICarsCategory iAllCarsCategory)
        {
            _allCars = iAllCars;
            _allCarsCategory = iAllCarsCategory;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Страница с автомобилями";
            CarsListViewModel obj = new CarsListViewModel();
            obj.allCars = _allCars.Cars;
            obj.currCategory = "Все автомобили";
            return View(obj);
        }
    }
}