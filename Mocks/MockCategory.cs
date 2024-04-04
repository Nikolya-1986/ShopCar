using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopCar.Interfaces;
using ShopCar.Models;

namespace ShopCar.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get 
            {
                return new List<Category>
                {
                    new Category { categoryName = "Электромобили", desc = "Современный вид транспорта", cars = null },
                    new Category { categoryName = "Классические автомобили", desc = "Машины с двигателем внутреннего сгорания", cars = null }
                };
            }
        }
    }
}