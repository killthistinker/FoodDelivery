using System.Threading.Tasks;
using FoodDelivery.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPointService _pointService;
        public HomeController(IPointService pointService)
        {
            _pointService = pointService;
        }

        public IActionResult Index()
        {
            var points = _pointService.GetPoints();
            return View(points);
        }

        public async Task<IActionResult> GetPointInfo(int id)
        {
            var point = await _pointService.GetPoint(id);
            return View(point);
        }
    }
}