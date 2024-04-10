using Microsoft.AspNetCore.Mvc;
using ShopCar.Interfaces;
using ShopCar.ViewModels;

namespace ShopCar.Controllers
{
    public class HomeController: Controller
    {
        private readonly IAllCars _carRepository;
        public HomeController(IAllCars carRepository)
        {
            _carRepository = carRepository;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                favCars = _carRepository.getFavCars,
            };
            return View(homeCars);
        }
    }
}