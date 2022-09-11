using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Data;
using FoodDelivery.Models;
using FoodDelivery.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly DeliveryContext _db;

        public BasketRepository(DeliveryContext db)
        {
            _db = db;
        }
        
        public IEnumerable<Basket> GetAll() => _db.Baskets;
        public void Create(Basket item) => _db.Baskets.Add(item);
        public void Update(Basket item) => _db.Baskets.Update(item);
        public void Remove(Basket item) => _db.Baskets.Remove(item);
        public void Save() => _db.SaveChanges();
        public Task SaveAsync() => _db.SaveChangesAsync();
        public Basket GetFirstOrDefaultByPointId(int id) =>_db.Points.Where(p => p.Id == id).Select(p => p.Basket).First();
    }
}