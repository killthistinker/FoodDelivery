using System.Threading.Tasks;
using FoodDelivery.Models;

namespace FoodDelivery.Repository.Interfaces
{
    public interface IBasketRepository : IRepository<Basket>
    {
        public Basket GetFirstOrDefaultByPointId(int id);
    }
}