using FoodDelivery.Models;
using FoodDelivery.Models.ViewModels;

namespace FoodDelivery.Helpers
{
    public static class DishMapper
    {
        public static Dish MapToDish(this DishViewModel self)
        {
            Dish dish = new Dish
            {
                Description = self.Description,
                Name = self.Name,
                Price = self.Pirce,
                PointId = self.PointId
            };
            return dish;
        }
    }
}