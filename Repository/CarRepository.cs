using Microsoft.EntityFrameworkCore;
using ShopCar.Interfaces;
using ShopCar.Models;

namespace ShopCar.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent appDBContent;
        public CarRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Car> Cars
        {
            get => appDBContent.Car.Include(c => c.Category);
        }
        public IEnumerable<Car> getFavCars
        {
            get => appDBContent.Car.Where(p => p.isFavorite).Include(c => c.Category);
        }
        public Car getObjCar(int carId) => appDBContent.Car.FirstOrDefault(p => p.id == carId);
    }
}