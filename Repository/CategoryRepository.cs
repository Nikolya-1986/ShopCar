using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopCar.Interfaces;
using ShopCar.Models;

namespace ShopCar.Repository
{
    public class CategoryRepository: ICarsCategory
    {
        private readonly AppDBContent appDBContent;
        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Category> AllCategories
        {
            get => appDBContent.Category;
        }
    }
}