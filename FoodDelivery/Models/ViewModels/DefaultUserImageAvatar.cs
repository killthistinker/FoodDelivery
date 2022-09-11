using FoodDelivery.Services.Abstractions;

namespace FoodDelivery.Models.ViewModels
{
    public class DefaultUserImageAvatar : IDefaultUserImageAvatar
    {
        private readonly string _path;

        public DefaultUserImageAvatar(string path)
        {
            _path = path;
        }

        public string GetPathToDefaultImage() => _path;
    }
}