using System.Threading.Tasks;
using FoodDelivery.Models;

namespace FoodDelivery.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    { 
        public Task<User> GetFirstOrDefaultByIdAsync(int id);
        public Task<User> GetFirstOrDefaultByNameAsync(string name);
    }
}