using System.Threading.Tasks;
using FoodDelivery.Models;

namespace FoodDelivery.Repository.Interfaces
{
    public interface ICustomerInfoRepository : IRepository<CustomerInfo>
    {
        public Task AddAsync(CustomerInfo item);
    }
}