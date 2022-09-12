using System.Threading.Tasks;
using FoodDelivery.Models;
using FoodDelivery.Models.ViewModels;

namespace FoodDelivery.Services.Abstractions
{
    public interface IEmailService
    {
        public Task SendEmailAsync(AddOrderViewModel model);
        
    }
}