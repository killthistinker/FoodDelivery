using FoodDelivery.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Data
{
    public class DeliveryContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Point> Points { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<OrderInfo> OrderInfos { get; set; }
        public DbSet<CustomerInfo> CustomerInfos { get; set; }
        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options)
        {
            
        }
    }
}