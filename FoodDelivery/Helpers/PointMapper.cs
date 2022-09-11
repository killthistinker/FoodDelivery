using System.Collections.Generic;
using FoodDelivery.Models;
using FoodDelivery.Models.ViewModels;
using FoodDelivery.Models.ViewModels.PointViewModels;

namespace FoodDelivery.Helpers
{
    public static class PointMapper
    {
        public static Point MapToPoint(this PointViewModel self)
        {
            Point point = new Point
            {
                Description = self.Description,
                Image = self.ImagePath,
                Name = self.Name,
                Dishes = new List<Dish>(),
                Basket = new Basket()
            };
            return point;
        }
    }
}