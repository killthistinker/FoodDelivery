using System.Threading.Tasks;
using FoodDelivery.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
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
    }
}