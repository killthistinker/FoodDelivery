using System.Threading.Tasks;
using FoodDelivery.Models;
using FoodDelivery.Models.ViewModels;

namespace FoodDelivery.Services.Abstractions
{
    public interface IOrderService
    {
        public Task<int> AddOrder(AddOrderViewModel model);
    }
}