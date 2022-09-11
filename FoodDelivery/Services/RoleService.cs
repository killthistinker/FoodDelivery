using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Enums;
using FoodDelivery.Models;
using FoodDelivery.Repository.Interfaces;
using FoodDelivery.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using IdentityResult = FoodDelivery.DataObjects.IdentityResult;

namespace FoodDelivery.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public RoleService(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddRole(int userId)
        {
            var user = await _userRepository.GetFirstOrDefaultByIdAsync(userId);
            var deleteRole = await _userManager.IsInRoleAsync(user, "administrator");
            if (deleteRole)
            {
                var addToRole = await _userManager.RemoveFromRoleAsync(user, "administrator");
                user.IamAdmin = false;
                _userRepository.Update(user);
                await _userRepository.SaveAsync();
                if(addToRole.Succeeded)  return new IdentityResult{StatusCodes = StatusCodes.Success};
            }
            var result = await _userManager.AddToRoleAsync(user, "administrator");
            user.IamAdmin = true;
            _userRepository.Update(user);
            await _userRepository.SaveAsync();
            if(result.Succeeded)  return new IdentityResult{StatusCodes = StatusCodes.Success};
            
            var errors = result.Errors.Select(error => error.Description).ToList();
            return new IdentityResult
            {
                ErrorMessages = errors, 
                StatusCodes = StatusCodes.Error
            };
        }
    }
}