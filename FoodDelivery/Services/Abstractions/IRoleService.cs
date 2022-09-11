using System.Threading.Tasks;
using FoodDelivery.DataObjects;

namespace FoodDelivery.Services.Abstractions
{
    public interface IRoleService
    {
        public Task<IdentityResult> AddRole(int userId);
    }
}