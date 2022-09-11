using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Models.ViewModels;
using FoodDelivery.Models.ViewModels.PointViewModels;
using FoodDelivery.Repository.Interfaces;
using FoodDelivery.Services.Abstractions;

namespace FoodDelivery.Services
{
    public class PointService : IPointService
    {
        private readonly IPointRepository _pointRepository;

        public PointService(IPointRepository pointRepository)
        {
            _pointRepository = pointRepository;
        }

        public PointIndexViewModel GetPoints()
        {
            var points = _pointRepository.GetAll();
            PointIndexViewModel model = new PointIndexViewModel { Points = points };
            return model;
        }

        public async Task<PointInfoViewModel> GetPoint(int id)
        {
            var point = await _pointRepository.FirstOrDefaultByIdAsync(id);
            if (point is null) return null;
            
            PointInfoViewModel model = new PointInfoViewModel
            {
                Id = point.Id,
                Description = point.Description,
                Image = point.Image,
                Name = point.Name,
                Dishes = point.Dishes,
                Basket = point.Basket
            };
            return model;
        }
    }
}