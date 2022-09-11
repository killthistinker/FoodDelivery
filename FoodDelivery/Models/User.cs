
using Microsoft.AspNetCore.Identity;

namespace FoodDelivery.Models
{
    public class User : IdentityUser<int>
    {
        public bool IamAdmin { get; set; }
    }
}