using System.Threading.Tasks;
using FoodDelivery.Models;

namespace FoodDelivery.Repository.Interfaces
{
    public interface IPointRepository : IRepository<Point>
    {
        public Task CreateAsync(Point point);
        public Task<Point> FirstOrDefaultByIdAsync(int pointId);
    }
}