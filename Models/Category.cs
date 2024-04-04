using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCar.Models
{
    public class Category
    {
        public int id { set; get; }
        public required string categoryName { set; get; }
        public required string desc { set; get; }
        public required List<Car> cars { set; get; }
    }
}