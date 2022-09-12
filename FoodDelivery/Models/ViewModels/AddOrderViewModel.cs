using System.Collections.Generic;

namespace FoodDelivery.Models.ViewModels
{
    public class AddOrderViewModel
    {
        public IEnumerable<OrderViewModel> Dishes { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}