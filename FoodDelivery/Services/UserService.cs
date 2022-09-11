using System.Threading.Tasks;
using FoodDelivery.Helpers;
using FoodDelivery.Models;
using FoodDelivery.Models.ViewModels;
using FoodDelivery.Repository.Interfaces;
using FoodDelivery.Services.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace FoodDelivery.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly UserManager<User> _userManager;

        public UserService(IUserRepository repository, UserManager<User> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }
        
        public async Task AddUser(RegistrationViewModel model)
        {
            User user = model.MapToUser();
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");
            }
        }

        public async Task DeleteUser(int id)
        {
            User user = await _repository.GetFirstOrDefaultByIdAsync(id);
            if (user is not null)
            {
                _repository.Remove(user);
                await _repository.SaveAsync();
            }
        }
    }
}