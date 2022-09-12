using System.Collections.Generic;
using System.Threading.Tasks;
using FoodDelivery.Data;
using FoodDelivery.Models;
using FoodDelivery.Repository.Interfaces;

namespace FoodDelivery.Repository
{
    public class OrderInfoRepository : IOrderInfoRepository
    {
        private readonly DeliveryContext _db;

        public OrderInfoRepository(DeliveryContext deliveryContext)
        {
            _db = deliveryContext;
        }

        public IEnumerable<OrderInfo> GetAll() => _db.OrderInfos;

        public void Create(OrderInfo item) => _db.OrderInfos.Add(item);

        public void Update(OrderInfo item) => _db.OrderInfos.Update(item);

        public void Remove(OrderInfo item) => _db.OrderInfos.Remove(item);

        public void Save() => _db.SaveChanges();

        public async Task SaveAsync() => await _db.SaveChangesAsync();

        public async Task AddAsync(OrderInfo item) => await _db.OrderInfos.AddAsync(item);
    }
}