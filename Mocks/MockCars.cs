using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopCar.Interfaces;
using ShopCar.Models;

namespace ShopCar.Mocks
{
    
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars {
            get
            {
                return new List<Car>
                {
                    new Car { name = "Tesla Model S", shortDesc = "Быстрый автомобиль", longDesc = "Красивый, тихий и очень быстрый автомобиль компании Tesla",
                        img = "https://upload.wikimedia.org/wikipedia/commons/2/20/Tesla_Model_S_%2828898945604%29.jpg", price = 65000, isFavorite = true, 
                        avalible = true, Category = _categoryCars.AllCategories.First() },

                    new Car { name = "Ford Focus", shortDesc = "Тихий и спокойный", longDesc = "Удобный автомобиль для городской жизни компании Ford",
                        img = "https://images.pexels.com/photos/1007410/pexels-photo-1007410.jpeg?auto=compress&cs=tinysrgb&w=600", price = 35000,
                        isFavorite = true, avalible = true, Category = _categoryCars.AllCategories.Last() },
                
                    new Car { name = "Mersedes C class", shortDesc = "Уютный и большой", longDesc = "Удобный автомобиль для городской жизни компании Mersedes",
                        img = "https://c4.wallpaperflare.com/wallpaper/297/946/451/mercedes-benz-sedan-mercedes-sedan-wallpaper-preview.jpg", price = 40000,
                        isFavorite = true, avalible = true, Category = _categoryCars.AllCategories.Last() }
                };
            }
        }
        public required IEnumerable<Car> getFavCars { get; set; }
        public Car getObjCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}