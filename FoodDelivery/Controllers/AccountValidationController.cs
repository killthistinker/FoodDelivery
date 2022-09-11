using System.Linq;
using FoodDelivery.Data;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.Controllers
{
    public class AccountValidationController : Controller
    {
        private readonly DeliveryContext _context;

        public AccountValidationController(DeliveryContext context)
        {
            _context = context;
        }

        public bool CheckAccountEmail(string email)
        {
            bool validation = !_context.Users.AsEnumerable().Any(p => p.Email.Equals(email));
            return validation;
        }

        public bool CheckAccountName(string userName)
        {
            bool validation = !_context.Users.AsEnumerable().Any(p => p.UserName.Equals(userName));
            return validation;
        }
    }
}