using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using  Microsoft.Extensions.DependencyInjection;
using ShopCar.Models;

namespace ShopCar
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if(!content.Category.Any()) // если нет объектов
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if(!content.Car.Any())
            {
                content.AddRange(
                    new Car { name = "Tesla Model S", shortDesc = "Быстрый автомобиль", longDesc = "Красивый, тихий и очень быстрый автомобиль компании Tesla",
                        img = "https://upload.wikimedia.org/wikipedia/commons/2/20/Tesla_Model_S_%2828898945604%29.jpg", price = 65000, isFavorite = true, 
                        avalible = true, Category = Categories["Электромобили"] },

                    new Car { name = "Ford Focus", shortDesc = "Тихий и спокойный", longDesc = "Удобный автомобиль для городской жизни компании Ford",
                        img = "https://images.pexels.com/photos/1007410/pexels-photo-1007410.jpeg?auto=compress&cs=tinysrgb&w=600", price = 35000,
                        isFavorite = true, avalible = true, Category = Categories["Классические автомобили"] },
                
                    new Car { name = "Mersedes C class", shortDesc = "Уютный и большой", longDesc = "Удобный автомобиль для городской жизни компании Mersedes",
                        img = "https://c4.wallpaperflare.com/wallpaper/297/946/451/mercedes-benz-sedan-mercedes-sedan-wallpaper-preview.jpg", price = 40000,
                        isFavorite = true, avalible = true, Category = Categories["Классические автомобили"] }
                );
            }
            content.SaveChanges(); // сохраяняет все изменения
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category { categoryName = "Электромобили", desc = "Современный вид транспорта", cars = null },
                        new Category { categoryName = "Классические автомобили", desc = "Машины с двигателем внутреннего сгорания", cars = null },
                    };
                    category = new Dictionary<string, Category>();
                    foreach(Category element in list)
                    {
                        category.Add(element.categoryName, element);
                    }
                }
                return category;
            }
        }
    }
}