using System.Collections.Generic;
using System.Threading.Tasks;
using FoodDelivery.Data;
using FoodDelivery.Models;
using FoodDelivery.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Repository
{
    public class CustomerInfoRepository : ICustomerInfoRepository
    {
        private readonly DeliveryContext _db;

        public CustomerInfoRepository(DeliveryContext db)
        {
            _db = db;
        }

        public IEnumerable<CustomerInfo> GetAll() => _db.CustomerInfos.Include(u => u.OrderInfos);
        public void Create(CustomerInfo item) => _db.CustomerInfos.Add(item);
        public void Update(CustomerInfo item) => _db.CustomerInfos.Update(item);
        public void Remove(CustomerInfo item) => _db.CustomerInfos.Remove(item);
        public void Save() => _db.SaveChanges();
        public async Task SaveAsync() => await _db.SaveChangesAsync();
        public async Task AddAsync(CustomerInfo item) => await _db.CustomerInfos.AddAsync(item);
    }
}