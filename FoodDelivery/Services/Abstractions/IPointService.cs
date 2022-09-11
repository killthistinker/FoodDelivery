using System.Threading.Tasks;
using FoodDelivery.Models.ViewModels;
using FoodDelivery.Models.ViewModels.PointViewModels;

namespace FoodDelivery.Services.Abstractions
{
    public interface IPointService
    {
        public PointIndexViewModel GetPoints();
        public Task<PointInfoViewModel> GetPoint(int id);
    }
}