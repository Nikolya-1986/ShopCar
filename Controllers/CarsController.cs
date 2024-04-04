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

        public CarsController(IAllCars allCars, ICarsCategory allCarsCategory)
        {
            _allCars = allCars;
            _allCarsCategory = allCarsCategory;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Страницв с автомобилями";
            CarsListViewModel cars = new CarsListViewModel();
            cars.allCars = _allCars.Cars;
            cars.currCategory = "Все автомобили";
            return View(cars);
        }
    }
}