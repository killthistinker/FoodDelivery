using System.Collections.Generic;

namespace FoodDelivery.Models.ViewModels.PointViewModels
{
    public class PointInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Basket Basket { get; set; }
        public IEnumerable<Dish> Dishes { get; set; }
        public int DishId { get; set; }
        public int PointId { get; set; }
    }
}