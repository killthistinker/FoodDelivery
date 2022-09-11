using FoodDelivery.Models.ViewModels;
using FoodDelivery.Repository;
using FoodDelivery.Repository.Interfaces;
using FoodDelivery.Services;
using FoodDelivery.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodDelivery.Helpers
{
    public static class ServiceConnector
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<UploadService>();
            services.AddScoped<IDishRepository, DishRepository>();
            services.AddScoped<IPointRepository, PointRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IManagerService, ManagerService>();
            services.AddTransient<IImageUploadService, ImageUploadService>();
            services.AddTransient<IDefaultUserImageAvatar>(_ =>
                new DefaultUserImageAvatar(configuration["PathToDefaultAvatar:Path"]));
            services.AddTransient<IPointService, PointService>();
            services.AddTransient<IBasketService, BasketService>();
            services.AddTransient<IRoleService, RoleService>();
            return services;
        }
    }
}