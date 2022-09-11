using System.Collections.Generic;
using System.Threading.Tasks;
using FoodDelivery.Data;
using FoodDelivery.Models;
using FoodDelivery.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DeliveryContext _db;

        public UserRepository(DeliveryContext db)
        {
            _db = db;
        }

        public IEnumerable<User> GetAll()
        {
            var users = _db.Users;
            return users;
        }

        public async Task<User> GetFirstOrDefaultByIdAsync(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<User> GetFirstOrDefaultByNameAsync(string name)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.UserName == name);
        }
        
        public void Create(User item) => _db.Add(item);
        public void Update(User item) => _db.Update(item);
        public void Remove(User item) => _db.Remove(item);
        public void Save() => _db.SaveChanges();
        public async Task SaveAsync() => await _db.SaveChangesAsync();
    }
}