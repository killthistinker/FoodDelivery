using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Helpers;
using FoodDelivery.Models;
using FoodDelivery.Models.ViewModels;
using FoodDelivery.Models.ViewModels.IndexViewModels;
using FoodDelivery.Models.ViewModels.PointViewModels;
using FoodDelivery.Repository.Interfaces;
using FoodDelivery.Services.Abstractions;


namespace FoodDelivery.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IPointRepository _pointRepository;
        private readonly IDishRepository _dishRepository;
        private readonly IImageUploadService _imageUploadService;
        private readonly IUserRepository _userRepository;

        public ManagerService(IPointRepository pointRepository, IDishRepository dishRepository, IImageUploadService imageUploadService, IUserRepository userRepository)
        {
            _pointRepository = pointRepository;
            _dishRepository = dishRepository;
            _imageUploadService = imageUploadService;
            _userRepository = userRepository;
        }

        public async Task AddPoint(PointViewModel model)
        {
            try
            {
                await _imageUploadService.CreateAsync(model, model.Name);
                Point point = model.MapToPoint();
                if (point is not null)
                {
                    await _pointRepository.CreateAsync(point);
                    await _pointRepository.SaveAsync();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task AddDish(DishViewModel model)
        {
            try
            {
                Dish dish = model.MapToDish();
                if (dish is not null)
                {
                    await _dishRepository.AddAsync(dish);
                    await _dishRepository.SaveAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteDish(int dishId)
        {
            var dish = await _dishRepository.FirstOrDefaultByIdAsync(dishId);
            if (dish is not null)
            {
                _dishRepository.Remove(dish);
                await _dishRepository.SaveAsync();
            }
        }

        public async Task DeletePoint(int pointId)
        {
            var point = await _pointRepository.FirstOrDefaultByIdAsync(pointId);
            if (point is not null)
            {
                _pointRepository.Remove(point);
                await _pointRepository.SaveAsync();
            }
        }

        public IndexDishViewModel GetAllDishes()
        {
            var dishes = _dishRepository.GetAll();
            if (!dishes.Any());
            IndexDishViewModel model = new IndexDishViewModel
            {
                Dishes = dishes,
                Model = new DishViewModel(),
                Points = _pointRepository.GetAll(),
            };
         
            return model;
        }

        public IndexPointViewModel GetAllPoints()
        {
            
            IEnumerable<Point> points = _pointRepository.GetAll();
            if (!points.Any()) return null;
            
            IndexPointViewModel model = new IndexPointViewModel
            {
                Points = points,
                Model = new PointViewModel()
            };
            model.Points = points;
            return model;
        }

        public IndexUserViewModel GetAllUsers()
        {
            var users = _userRepository.GetAll();
            if (!users.Any()) return null;
            IndexUserViewModel model = new IndexUserViewModel { Users = users };
            return model;
        }
    }
}