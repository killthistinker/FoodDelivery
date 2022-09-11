using FoodDelivery.Models;
using FoodDelivery.Models.ViewModels;

namespace FoodDelivery.Helpers
{
    public static class UserRegistrationMapper
    {
        public static User MapToUser(this RegistrationViewModel self)
        {
            User user = new User()
            {
                Email = self.Email,
                UserName = self.UserName,
                IamAdmin = false
            };
            return user;
        }
    }
}