using System.Collections.Generic;

namespace FoodDelivery.Models.ViewModels.IndexViewModels
{
    public class IndexDishViewModel
    {
        public IEnumerable<Dish> Dishes { get; set; }
        public IEnumerable<Point> Points { get; set; }
        public DishViewModel Model { get; set; }
    }
}