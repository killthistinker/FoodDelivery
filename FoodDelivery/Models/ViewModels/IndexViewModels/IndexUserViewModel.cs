using System.Collections.Generic;

namespace FoodDelivery.Models.ViewModels.IndexViewModels
{
    public class IndexUserViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public RegistrationViewModel Model { get; set; }
    }
}