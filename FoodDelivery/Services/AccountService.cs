using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Enums;
using FoodDelivery.Helpers;
using FoodDelivery.Models;
using FoodDelivery.Models.ViewModels;
using FoodDelivery.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using IdentityResult = FoodDelivery.DataObjects.IdentityResult;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace FoodDelivery.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IdentityResult> Register(RegistrationViewModel model)
        {
            if (model is null) return new IdentityResult
            {
                StatusCodes = StatusCodes.Error, 
                ErrorMessages = new List<string>{"Внутренняя ошибка"},
            };
           
                User user = model.MapToUser();
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "user");
                    await _signInManager.SignInAsync(user, false);
                    return new IdentityResult{StatusCodes = StatusCodes.Success};
                }
                var errors = result.Errors.Select(error => error.Description).ToList();

                return new IdentityResult
                {
                    ErrorMessages = errors, 
                    StatusCodes = StatusCodes.Error
                };
            }
        
            public async Task<IdentityResult> LogIn(LoginViewModel model)
            {
            var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is not null)
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(
                    user,
                    model.Password,
                    model.RememberMe,
                    false
                );
                if (result.Succeeded)
                    return new IdentityResult {StatusCodes = StatusCodes.Success};
            }
            return new IdentityResult
            {
            StatusCodes = StatusCodes.Error,
            ErrorMessages = new List<string>{"Неправильный логин и (или) пароль"}
            };
        }

        public async Task LogOf()
            => await _signInManager.SignOutAsync();
    }
}