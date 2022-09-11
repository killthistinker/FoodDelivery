using System.Threading.Tasks;
using FoodDelivery.Models;

namespace FoodDelivery.Repository.Interfaces
{
    public interface IDishRepository : IRepository<Dish>
    {
        public Task AddAsync(Dish dish);
        public Task<Dish> FirstOrDefaultByIdAsync(int dishId);
    }
}