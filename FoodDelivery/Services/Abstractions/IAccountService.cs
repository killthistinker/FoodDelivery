using System.Threading.Tasks;
using FoodDelivery.Models.ViewModels;
using IdentityResult = FoodDelivery.DataObjects.IdentityResult;

namespace FoodDelivery.Services.Abstractions
{
    public interface IAccountService
    {
        public Task<IdentityResult> Register(RegistrationViewModel model);
        public Task<IdentityResult> LogIn(LoginViewModel model);
        public Task LogOf();
    }
}