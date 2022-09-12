using System.Threading.Tasks;
using FoodDelivery.DataObjects;
using FoodDelivery.Enums;
using FoodDelivery.Models.ViewModels;
using FoodDelivery.Models.ViewModels.PointViewModels;
using FoodDelivery.Repository.Interfaces;
using FoodDelivery.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    [Authorize(Roles = "admin, administrator")]
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;
        private readonly IRoleService _roleService;
        private readonly ICustomerInfoRepository _infoRepository;
    

        public ManagerController(IManagerService managerService, IRoleService roleService, ICustomerInfoRepository infoRepository)
        {
            _managerService = managerService;
            _roleService = roleService;
            _infoRepository = infoRepository;
        }

        [HttpGet]
        public IActionResult IndexDish()
        {
            var dishes = _managerService.GetAllDishes();
            return View(dishes);
        }
        
        [HttpGet]
        public IActionResult IndexPoint()
        {
            var points = _managerService.GetAllPoints();
            return View(points);
        }

        [HttpGet]
        public IActionResult IndexOrders()
        {
            var orders = _infoRepository.GetAll();
            return View(orders);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddPoint(PointViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction("IndexPoint");
            await _managerService.AddPoint(model);
            return RedirectToAction("IndexPoint");
        }
        
        
        [HttpPost]
        [Authorize(Roles = "admin, administrator")]
        public async Task<IActionResult> AddDish(DishViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction("IndexDish");
            await _managerService.AddDish(model);
            return RedirectToAction("IndexDish");
        }

        [HttpPost]
        [Authorize(Roles = "admin, administrator")]
        public async Task<IActionResult> DeleteDish(int id)
        {
            await _managerService.DeleteDish(id);
            return Ok(200);
        }
        
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeletePoint(int id)
        {
            await _managerService.DeletePoint(id);
            return Ok(200);
        }
        
        [HttpGet]
        [Authorize(Roles = "admin")]
        public  IActionResult GetUsers()
        {
            var users = _managerService.GetAllUsers();
            return View(users);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddRole(int userId)
        {
            var result = await _roleService.AddRole(userId);
            if (result.StatusCodes != StatusCodes.Success)
                return RedirectToAction("Error", "Errors", new { statusCode = 404 });
            
            return Ok(200);
        }
    }
}