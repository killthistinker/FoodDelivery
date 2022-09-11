using System.Collections.Generic;
using System.Threading.Tasks;
using FoodDelivery.Data;
using FoodDelivery.Models;
using FoodDelivery.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Repository
{
    public class DishRepository : IDishRepository
    {
        private readonly DeliveryContext _db;

        public DishRepository(DeliveryContext db)
        {
            _db = db;
        }

        public IEnumerable<Dish> GetAll() => _db.Dishes.Include(p => p.Point);
        public void Create(Dish item) => _db.Dishes.Add(item);
        public void Update(Dish item) => _db.Dishes.Update(item);
        public void Remove(Dish item) => _db.Dishes.Remove(item);
        public void Save() => _db.SaveChanges();
        public async Task SaveAsync() => await _db.SaveChangesAsync();
        public async Task AddAsync(Dish dish) => await _db.Dishes.AddAsync(dish);
        public async Task<Dish> FirstOrDefaultByIdAsync(int dishId)
            => await _db.Dishes.FirstOrDefaultAsync(d => d.Id == dishId);
    }
}