using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCar.Models
{
    public class Car
    {
        public int id { set; get; }
        public required string name { set; get; }
        public required string shortDesc { set; get; }
        public required string longDesc { set; get; }
        public required string img { set; get; }
        public ushort price { set; get; }
        public bool isFavorite { set; get; }
        public bool avalible { set; get; }
        public int categoryId { set; get; }
        public virtual required Category Category { set; get; }
    }
}