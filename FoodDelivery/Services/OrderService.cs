using System.Threading.Tasks;
using FoodDelivery.Enums;
using FoodDelivery.Models;
using FoodDelivery.Models.ViewModels;
using FoodDelivery.Repository.Interfaces;
using FoodDelivery.Services.Abstractions;

namespace FoodDelivery.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICustomerInfoRepository _customerInfoRepository;
        private readonly IOrderInfoRepository _orderInfoRepository;

        public OrderService(ICustomerInfoRepository customerInfoRepository, IOrderInfoRepository orderInfoRepository)
        {
            _customerInfoRepository = customerInfoRepository;
            _orderInfoRepository = orderInfoRepository;
        }

        public async Task<int> AddOrder(AddOrderViewModel model)
        {
            if (model is null) return (int)StatusCodes.Error;
            if (model.Address is null || model.Email is null || model.Phone is null) return (int)StatusCodes.Error;
            CustomerInfo customerInfo = new CustomerInfo();
            foreach (var dish in model.Dishes)
            {
                OrderInfo orderInfo = new OrderInfo
                {
                    DishId = dish.Dish.Id,
                    DishCount = dish.DishCount
                };
                await _orderInfoRepository.AddAsync(orderInfo);
                customerInfo.OrderInfos.Add(orderInfo);
            }
            customerInfo.Email = model.Email;
            customerInfo.Phone = model.Phone;
            customerInfo.Address = model.Address;

            await _customerInfoRepository.AddAsync(customerInfo);
            await _customerInfoRepository.SaveAsync();

            return (int)StatusCodes.Success;
        }
    }
}