using System.Threading.Tasks;
using FoodDelivery.Models;

namespace FoodDelivery.Repository.Interfaces
{
    public interface IOrderInfoRepository : IRepository<OrderInfo>
    {
        public Task AddAsync(OrderInfo item);
    }
}