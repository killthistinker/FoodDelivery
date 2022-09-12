using System.Threading.Tasks;
using FoodDelivery.Enums;
using FoodDelivery.Models;
using FoodDelivery.Models.ViewModels;
using FoodDelivery.Services.Abstractions;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;
        private readonly IEmailService _emailService;

        public BasketController(IBasketService basketService, IOrderService orderService, IEmailService emailService)
        {
            _basketService = basketService;
            _orderService = orderService;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<JsonResult> AddDish(int pointId, int dishId)
        {
            var model = await _basketService.AddDish(dishId, pointId);

            return Json(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(int pointId)
        {
            var model = await _basketService.GetOrders(pointId);

            if (model is null) return Ok(500);

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int orderId, int pointId)
        {
            var balance = await _basketService.DeleteOrder(orderId, pointId);
            if (balance is null) return Ok(500);
            return Ok(balance);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderViewModel model)
        {
            var result = await _orderService.AddOrder(model);
            if (result == (int)StatusCodes.Error) return Ok(500);
            await _emailService.SendEmailAsync(model);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> ClearBasket(int pointId)
        {
            var result = await _basketService.Clear(pointId);
            return Ok(result);
        }
    }
}