using System.Collections.Generic;
using System.Threading.Tasks;
using FoodDelivery.Models.ViewModels;
using FoodDelivery.Models.ViewModels.BasketViewModels;

namespace FoodDelivery.Services.Abstractions
{
    public interface IBasketService
    {
        public Task<List<BasketViewModel>> AddDish(int dishId, int pointId);
        public Task<List<BasketViewModel>> GetOrders(int pointId);
        public Task<BalanceViewModel> DeleteOrder(int orderId, int pointId);
        public Task<int> Clear(int pointId);
    }
}