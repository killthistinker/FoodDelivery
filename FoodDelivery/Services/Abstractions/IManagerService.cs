using System.Collections.Generic;
using System.Threading.Tasks;
using FoodDelivery.Models;
using FoodDelivery.Models.ViewModels;
using FoodDelivery.Models.ViewModels.PointViewModels;

namespace FoodDelivery.Services.Abstractions
{
    public interface IManagerService
    {
        public Task AddPoint(PointViewModel model);
        public Task AddDish(DishViewModel model);
        public Task DeleteDish(int dishId);
        public Task DeletePoint(int pointId);
        public IndexDishViewModel GetAllDishes();
        public IndexPointViewModel GetAllPoints();
        public IndexUserViewModel GetAllUsers();
    }
}