using System.Threading.Tasks;
using FoodDelivery.Models.ViewModels;

namespace FoodDelivery.Services.Abstractions
{
    public interface IUserService
    {
        public Task AddUser(RegistrationViewModel model);
        public Task DeleteUser(int id);
    }
}