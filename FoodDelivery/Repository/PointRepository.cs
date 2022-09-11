using System.Collections.Generic;
using System.Threading.Tasks;
using FoodDelivery.Data;
using FoodDelivery.Models;
using FoodDelivery.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Repository
{
    public class PointRepository : IPointRepository
    {
        private readonly DeliveryContext _db;

        public PointRepository(DeliveryContext db)
        {
            _db = db;
        }

        public IEnumerable<Point> GetAll() => _db.Points;
        public void Create(Point item) => _db.Points.Add(item);
        public async Task CreateAsync(Point item) => await _db.Points.AddAsync(item);

        public async Task<Point> FirstOrDefaultByIdAsync(int pointId)
            => await _db.Points.Include(p => p.Dishes).Include(p => p.Basket).ThenInclude(p => p.Orders).FirstOrDefaultAsync(p => p.Id == pointId);

        public void Update(Point item) => _db.Points.Update(item);
        public void Remove(Point item) => _db.Points.Remove(item);
        public void Save() => _db.SaveChanges();
        public async Task SaveAsync() => await _db.SaveChangesAsync();
    }
}