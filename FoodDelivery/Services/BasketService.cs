using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Models;
using FoodDelivery.Models.ViewModels.BasketViewModels;
using FoodDelivery.Repository.Interfaces;
using FoodDelivery.Services.Abstractions;

namespace FoodDelivery.Services
{
    public class BasketService : IBasketService
    {
        private readonly IPointRepository _pointRepository;
        private readonly IDishRepository _dishRepository;
        private readonly IBasketRepository _basketRepository;

        public BasketService(IPointRepository pointRepository, IDishRepository dishRepository, IBasketRepository basketRepository)
        {
            _pointRepository = pointRepository;
            _dishRepository = dishRepository;
            _basketRepository = basketRepository;
        }

        public async Task<List<BasketViewModel>> AddDish(int dishId, int pointId)
        {
            var point = await _pointRepository.FirstOrDefaultByIdAsync(pointId);
            if (point is null) return null;
            
            var dish = await _dishRepository.FirstOrDefaultByIdAsync(dishId);
            if (dish is null) return null;
            
            point.Basket.Orders.Add(new Order{Dish = dish});
            point.Basket.Sum += dish.Price;
            _pointRepository.Update(point);
            await _pointRepository.SaveAsync();
            
            var model = GetOrdersCount(point);
            return model ?? null;
        }

        public async Task<List<BasketViewModel>> GetOrders(int pointId)
        {
            var point = await _pointRepository.FirstOrDefaultByIdAsync(pointId);
            if (point is null) return null;
            var model = GetOrdersCount(point);
            return model ?? null;
        }

        public async Task<BalanceViewModel> DeleteOrder(int orderId, int pointId)
        {
            var point = await _pointRepository.FirstOrDefaultByIdAsync(pointId);
            if(point is null) return null;
            
            var orders = point.Basket.Orders.FindAll(u => u.DishId == orderId);
            for (int i = 0; i < orders.Count(); i++)
            {
                point.Basket.Orders.Remove(orders[i]);
                point.Basket.Sum -= orders[i].Dish.Price;
            }
            
            _basketRepository.Update(point.Basket);
            _pointRepository.Update(point);
            await _basketRepository.SaveAsync();
            await _pointRepository.SaveAsync();
            return new BalanceViewModel { Balance = point.Basket.Sum };
        }

        private List<BasketViewModel> GetOrdersCount(Point point)
        {
            List<BasketViewModel> viewModel = new List<BasketViewModel>();
            var orderDistinct = point.Basket.Orders.Select(p => p.Dish).Distinct().ToList();
            for (int i = 0; i < orderDistinct.Count(); i++)
            {
                BasketViewModel addToBasket = new BasketViewModel();
                addToBasket.Dish = orderDistinct[i];
                addToBasket.DishCount = point.Basket.Orders.Count(b => b.DishId == orderDistinct[i].Id);
                viewModel.Add(addToBasket);
            }

            return viewModel;
        }
    }
}