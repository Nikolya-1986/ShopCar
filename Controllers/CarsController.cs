using Microsoft.AspNetCore.Mvc;
using ShopCar.Interfaces;
using ShopCar.Models;
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

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars;
            string carentCategory = "";
            if(string.IsNullOrEmpty(category)) // пустая ли строка
            {
                cars = _allCars.Cars.OrderBy(i => i.id);
            } else {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))// игнорируем регистры
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Электромобили")).OrderBy(i => i.id);
                    carentCategory = "Электромобили";
                } else
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Классические автомобили")).OrderBy(i => i.id);
                     carentCategory = "Классические автомобили";
                }
            }
            var carObj = new CarsListViewModel
            {
                allCars = cars,
                currCategory = carentCategory,
            };
            ViewBag.Title = "Страница с автомобилями";
            return View(carObj);
        }
    }
}